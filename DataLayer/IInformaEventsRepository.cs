using System.Collections.Generic;
using System.Linq;
using InformaEventsAPI.Core.EntityLayer;

namespace InformaEventsAPI.Core.DataLayer
{
    public interface IInformaEventsRepository
    {
        void Dispose();
        IQueryable<Event> GetEvents(int pageSize, int pageNumber, string searchTerm);
    }
}