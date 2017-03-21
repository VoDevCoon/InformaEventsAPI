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

            query = query.Include(p=>p.EventCategory)
                         .Where(p=>p.EventCategory.Any(c=>c.TermTaxonomyId==eventCategory))
                         .Skip(pageSize*(pageNumber-1))
                         .Take(pageSize);;

            query = query.Select(p=>new Post()
                {
                    PostMetas = p.PostMetas
                                 .Where(pm=>pm.MetaKey.Equals("single_address_string")||
                                            pm.MetaKey.Equals("single_start_dates_sting")||
                                            pm.MetaKey.Equals("excerpt")||
                                            pm.MetaKey.Equals("duration")||
                                            pm.MetaKey.Equals("_thumbnail_id")||
                                            pm.MetaKey.Equals("event_code")||
                                            pm.MetaKey.Equals("event_type")),
                    Id = p.Id,
                    PostTitle=p.PostTitle,
                    PostStatus=p.PostStatus,
                    PostType=p.PostType                    

                });

            // var query2 = query.ToList();

            //             var index=0;
            //             foreach(var p in query2)
            //             {

            //                 System.Console.WriteLine($"{index++}:{p.PostTitle}");

            //                 foreach(var pm in p.PostMetas)
            //                 {
            //                     System.Console.WriteLine($"\t\t{pm.MetaKey}:{pm.MetaValue}");
            //                 }
            //          }

            return query;
        }
    }
}