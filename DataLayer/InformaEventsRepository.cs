using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InformaEventsAPI.Core.DataLayer;
using InformaEventsAPI.Core.EntityLayer;
using System.Threading.Tasks;
using InformaEventsAPI.Extensions;

namespace InformaEventsAPI.Core.DataLayer
{
    public class InformaEventsRepository : IInformaEventsRepository
    {
        private InformaWordPressDbContext _wpdbcontext;
        private bool _disposed;

        public InformaEventsRepository(InformaWordPressDbContext wpdbcontext)
        {
            _wpdbcontext = wpdbcontext;
        }
        public void Dispose()
        {
            if(!_disposed)
            {
                if(_wpdbcontext != null)
                {
                    _wpdbcontext.Dispose();

                    _disposed = true;
                }
            }
        }

        public IQueryable<Post> GetPosts(int pageSize,
                                         int pageNumber,
                                         string eventType,
                                         string eventStatus, 
                                         int eventCategory, 
                                         string searchTerm)
        {
            var query= _wpdbcontext.Posts
                    .Where(p=>p.PostType.ToLower().Equals(eventType)
                            &&p.PostStatus.ToLower().Equals(eventStatus));

            if(!String.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p=>p.PostTitle.ToLower().Contains(searchTerm));
            }

            query = query.Include(p=>p.PostCategoy)
                         .Where(p=>p.PostCategoy.Any(c=>c.TermTaxonomyId==eventCategory));

            var queryOrderbyHelper = query.Join(_wpdbcontext.PostMetas, 
                                                p=>p.Id, pm=>pm.PostId, 
                                                (p, pm)=>new{p.Id, p.PostTitle, pm.MetaKey, pm.MetaValue})
                                    .Where(p=>p.MetaKey.Equals("single_start_dates_sting"))
                                    .Select(f1=> new {
                                        PostId=f1.Id,
                                        PostTitle=f1.PostTitle,
                                        StartDate=f1.MetaValue.UnixTimeStampToDateTime()
                                    })
                                    .OrderBy(f2=>f2.StartDate).ThenBy(f2=>f2.PostTitle)
                                    .Skip(pageSize*(pageNumber-1))
                                    .Take(pageSize);

            query = query.Join(queryOrderbyHelper, p=>p.Id, qoh=>qoh.PostId, (p, qoh)=>new{p,qoh.StartDate})
                    .OrderBy(f1=>f1.StartDate).ThenBy(f1=>f1.p.PostTitle)
                    .Select(f2=>new Post
                {   
                    PostMetas = f2.p.PostMetas
                                 .Where(pm=>pm.MetaKey.Equals("single_address_string")||
                                            pm.MetaKey.Equals("single_start_dates_sting")||
                                            pm.MetaKey.Equals("excerpt")||
                                            pm.MetaKey.Equals("duration")||
                                            pm.MetaKey.Equals("_thumbnail_id")||
                                            pm.MetaKey.Equals("event_code")||
                                            pm.MetaKey.Equals("event_type")),
                    Id = f2.p.Id,
                    PostTitle=f2.p.PostTitle,
                    PostStatus=f2.p.PostStatus,
                    PostType=f2.p.PostType,
                    ThumbnailPostId= f2.p.PostMetas.Where(pm=>pm.MetaKey.Equals("_thumbnail_id")).Select(pm=>pm.MetaValue).FirstOrDefault()
                });

            return query;
        }

        public Post GetPost(int postId)
        {
            return _wpdbcontext.Posts.Find(postId);
        }

        public IQueryable<EventCategory> GetPostCategory(int postId)
        {
            var query = _wpdbcontext.TermTaxonomies
                        .Join(_wpdbcontext.TermsRelationships, tt=>tt.TermTaxonomyId, tr=>tr.TermTaxonomyId
                        , (tt, tr)=>new{ObjectId=tr.ObjectId, TermId=tt.TermId, Taxonomy=tt.Taxonomy, Description=tt.Description, Parent=tt.Parent, Count=tt.Count}
                        ).Where(c=>c.ObjectId==postId&&c.Taxonomy.Equals("product_cat"))
                        .Join(_wpdbcontext.Terms, q=>q.TermId, t=>t.TermId, (q,t)=>new EventCategory()
                        {
                            WPTermId=t.TermId,
                            Name=t.Name
                        });
            return query;
        }
    }
}