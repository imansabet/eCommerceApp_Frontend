public class ServiceResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public ServiceResponse(bool success = false, string message = "", string Message = null)
    {
        Success = success;
        Message = message;
    }
}