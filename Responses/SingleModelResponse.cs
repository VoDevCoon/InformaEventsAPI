using System;

namespace InformaEventsAPI.Responses
{
    public class SingleModelResponse<T> : ISingleModelResponse<T>
    {
        public T Model { get; set; }
        public bool DidError { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}