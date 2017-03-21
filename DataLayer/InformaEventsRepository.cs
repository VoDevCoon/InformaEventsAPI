using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InformaEventsAPI.Core.DataLayer;
using InformaEventsAPI.Core.EntityLayer;
using System.Threading.Tasks;

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

        public IQueryable<Post> GetPosts(int pageSize, int pageNumber, string eventType, int eventCategory, string searchTerm)
        {
            // var query= _wpdbcontext.Posts.Where(p=>p.PostType.ToLower().Equals("product")&&p.PostStatus.ToLower().Equals("publish"));

            // if(!String.IsNullOrEmpty(searchTerm))
            // {
            //     query = query.Where(p=>p.PostTitle.ToLower().Contains(searchTerm));
            // }

            // query = query.Include(p=>p.PostMetas)
            //             .Where(p=>p.PostMetas.Any(pm=>pm.PostId==p.Id&&pm.MetaKey.Equals("event_type")&&pm.MetaValue.Equals(eventType)))
            //             .Skip(pageSize*(pageNumber-1))
            //             .Take(pageSize);

            var query2 = from post in _wpdbcontext.Posts
                        //join termRelationship in _wpdbcontext.TermsRelationships on post.Id equals termRelationship.ObjectId
                        //where termRelationship.TermTaxonomyId==eventCategory
                        where post.PostType==eventType && post.PostStatus=="publish"
                        join postmeta in _wpdbcontext.PostMetas on post.Id equals postmeta.PostId
                        into metaGroup
                        join category in _wpdbcontext.TermsRelationships on post.Id equals category.ObjectId
                        where category.TermTaxonomyId == 77
                        select(
                            new Post
                            {
                                Id=post.Id,
                                PostTitle=post.PostTitle,
                                PostMetas=metaGroup
                            });

                            var posts = query2.Skip(pageSize*(pageNumber-1))
                        .Take(pageSize).ToList();
            return query2.Skip(pageSize*(pageNumber-1))
                        .Take(pageSize);
        }
    }
}