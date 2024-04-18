namespace Domain.Errors;

public struct ApiException
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Details { get; set; }

    public ApiException(int code,string? message = null,string? details = null)
    {
        StatusCode = code;
        Details = details;
        Message = message;
    }
}