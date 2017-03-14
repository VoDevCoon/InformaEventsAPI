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

        public IQueryable<Post> GetPosts(int pageSize, int pageNumber, string category, string searchTerm)
        {
            var query= _wpdbcontext.Posts.Where(p=>p.PostType.ToLower().Equals("product")).Skip(pageSize*pageNumber).Take(pageSize);

            if(!String.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p=>p.PostTitle.ToLower().Contains(searchTerm));
            }


            if(!String.IsNullOrEmpty(category))
            {
                query = query.Include(p=>p.PostMetas)
                            .Where(p=>p.PostMetas.Contains(pm.Equals("event_type")&&pm.MetaValue.Equals(category)));
            }

             var posts = 



            return posts;

        }

        public IQueryable<PostMeta> GetTest(int postid)
        {
            return _wpdbcontext.PostMeta.Where(p=>p.PostId==postid);
        }
    }
}