using System;
using System.Collections.Generic;
using System.Linq;
using InformaEventsAPI.Core.DataLayer;
using InformaEventsAPI.Core.EntityLayer;

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

        public IQueryable<Event> GetEvents(int pageSize, int pageNumber, string searchTerm)
        {
            var events = new List<Event>();

            var queryPosts = _wpdbcontext.Posts.Where(p=>p.PostType.ToLower().Equals("product")).Skip(pageSize*pageNumber).Take(pageSize);

            if(!String.IsNullOrEmpty(searchTerm))
            {
                queryPosts = queryPosts.Where(p=>p.PostTitle.ToLower().Contains(searchTerm));
            }

            var posts = queryPosts.ToList();

            foreach(var post in posts)
            {
                var postMetaQuery = _wpdbcontext.PostMeta.Where(pm=>pm.PostID==post.Id);

                post.PostMetas = postMetaQuery.ToList();

                events.Add(new Event
                {
                    Title = post.PostTitle,
                    ShortDescription = post.PostMetas.Where(pm=>pm.MetaKey.ToLower().Equals("excerpt")).Select(pm=>pm.MetaValue).FirstOrDefault(),
                    StartDate = new DateTime(1970,1,1,0,0,0,0).AddSeconds(Math.Round(Convert.ToDouble(post.PostMetas.Where(pm=>pm.MetaKey.ToLower().Equals("single_start_dates_sting")).Select(pm=>pm.MetaValue).FirstOrDefault()))).ToLocalTime(),
                });
            }

            return events.AsQueryable();

        }

        public IQueryable<PostMeta> GetTest(int postid)
        {
            return _wpdbcontext.PostMeta.Where(p=>p.PostID==postid);
        }
    }
}