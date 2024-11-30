namespace Ambev.DeveloperEvaluation.Common;

public class ApiResponseWithData<T> : ApiResponse
{
    public bool Success { get; set; }
    public T? Data { get; set; }
}
