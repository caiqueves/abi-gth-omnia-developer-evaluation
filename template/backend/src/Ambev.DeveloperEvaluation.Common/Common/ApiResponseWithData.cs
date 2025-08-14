namespace Ambev.DeveloperEvaluation.Common;

public class ApiResponseWithData<T> : ApiResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public new T? Data { get; set; }
}
