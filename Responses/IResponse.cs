namespace InformaEventsAPI.Responses
{
    public interface IResponse
    {
        bool DidError { get; set; }
        string Message { get; set; }
        string ErrorMessage { get; set; }
    }
}