using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace InformaEventsAPI.Responses
{
    public interface IListModelResponse<T> : IResponse
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
        IEnumerable<T> Model { get; set; }
    }
}