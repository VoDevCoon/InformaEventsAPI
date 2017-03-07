using System.Net;
using InformaEventsAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InformaEventsAPI.Extensions
{
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse<T>(this IListModelResponse<T> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NoContent;
            }

            return new ObjectResult(response) {StatusCode = (int)status};
        }

        public static IActionResult ToHttpResponse<T>(this ISingleModelResponse<T> response)
        {
            var status = HttpStatusCode.OK;

            if(response.DidError)
            {
                status = HttpStatusCode.InternalServerError;
            }
            else if (response.Model == null)
            {
                status = HttpStatusCode.NoContent;
            }

            return new ObjectResult(response) {StatusCode = (int)status};
        }
    }
}