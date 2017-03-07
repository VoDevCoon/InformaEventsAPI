using System;
using System.Collections.Generic;

namespace InformaEventsAPI.Responses
{
    public class ListModelResponse<T> : IListModelResponse<T>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T> Model { get; set; }
        public bool DidError { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}