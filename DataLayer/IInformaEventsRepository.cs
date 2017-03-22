using System.Linq;
using InformaEventsAPI.Core.EntityLayer;

namespace InformaEventsAPI.Core.DataLayer
{
    public interface IInformaEventsRepository
    {
        void Dispose();
        IQueryable<Post> GetPosts(int pageSize, int pageNumber, string eventType, string eventStatus, int eventCategory, string searchTerm);
        Post GetPost(int postId);
        IQueryable<EventCategory> GetPostCategory(int postId);
    }
}