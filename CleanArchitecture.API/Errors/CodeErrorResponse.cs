namespace CleanArchitecture.API.Errors;

public class CodeErrorResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public CodeErrorResponse(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageStatusCode(statusCode);
    }
    private string GetDefaultMessageStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "An error has occured, please try again.",
            401 => "You are not authorized to perform this action.",
            404 => "Resource not found.",
            500 => "An error has occured, please try again.",
            _ => string.Empty
        };
    }
}