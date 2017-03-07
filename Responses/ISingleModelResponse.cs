namespace InformaEventsAPI.Responses
{
    public interface ISingleModelResponse<T> : IResponse
    {
        T Model{get; set;}
    }
}