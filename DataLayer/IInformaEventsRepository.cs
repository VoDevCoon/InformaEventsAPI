using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformaEventsAPI.Core.EntityLayer;

namespace InformaEventsAPI.Core.DataLayer
{
    public interface IInformaEventsRepository
    {
        void Dispose();
        IQueryable<Post> GetPosts(int pageSize, int pageNumber, string evnetType, string searchTerm);
        IQueryable<PostMeta> GetTest(int id);
        
    }
}