using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InformaEventsAPI.Core.DataLayer;
using InformaEventsAPI.Responses;
using InformaEventsAPI.ViewModels;
using System.Linq;
using InformaEventsAPI.Extensions;
using Microsoft.EntityFrameworkCore;

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

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose();
        }

        [HttpGetAttribute]
        [RouteAttribute("Events")]
        public async Task<IActionResult> GetEvents(int? pageSize=10, int? pageNumber=1, string searchTerm = null)
        {
            var response = new ListModelResponse<EventViewModel>() as IListModelResponse<EventViewModel>;

            try
            {
                response.PageSize = (int)pageSize;
                response.PageNumber = (int)pageNumber;

                response.Model = await _repository
                                    .GetEvents(response.PageSize, response.PageNumber, searchTerm)
                                    .Select(item=>item.ToViewModel())
                                    .ToListAsync();

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch(Exception ex)
            {
                response.DidError = true;
                response.Message = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}