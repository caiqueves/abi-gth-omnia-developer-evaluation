using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Common;

public class ApiResponseError
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; } 
    public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];
}
