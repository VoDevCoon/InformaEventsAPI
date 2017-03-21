using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InformaEventsAPI.Core.DataLayer;
using InformaEventsAPI.Responses;
using InformaEventsAPI.ViewModels;
using System.Linq;
using InformaEventsAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using InformaEventsAPI.Core.EntityLayer;
using System.Collections.Generic;

namespace InformaEventsAPI.Controllers
{
    [RouteAttribute("api/[Controller]")]
    public class EventController : Controller
    {
        private IInformaEventsRepository _repository;
        public EventController(IInformaEventsRepository repository)
        {
            _repository = repository;
        }

        // protected override void Dispose(bool disposing)
        // {
        //     _repository.Dispose();
        //     base.Dispose();
        // }

        [HttpGetAttribute]
        [RouteAttribute("Events")]
        public async Task<IActionResult> GetEvents(int? pageSize=10, int? pageNumber=1, string eventType = null, int? eventCategory=77,string searchTerm = null)
        {
            var response = new ListModelResponse<EventViewModelList>() as IListModelResponse<EventViewModelList>;

            try
            {
                response.PageSize = (int)pageSize;
                response.PageNumber = (int)pageNumber;
                var category = (int) eventCategory;
                var eventViewModels = new List<EventViewModel>();

                response.Model = await _repository
                                .GetPosts(response.PageSize, response.PageNumber, eventType, category, searchTerm)
                                .Select(p=>p.ToEvent().ToViewModelEventList())
                                .ToListAsync();

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch(Exception ex)
            {
                throw ex;
                response.DidError = true;
                response.Message = ex.StackTrace;
            }

            return response.ToHttpResponse();
        }
    }
}