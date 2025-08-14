namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class ListUserRequest
{
    public int Page { get; set; } = 1;

    /// <summary>
    /// Size por page
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// Order type asc / desc
    /// </summary>
    public string Order { get; set; } = "ResumeAt";

    public ListUserRequest(int page, int size, string order)
    {
        Page = page;
        Size = size;
        Order = order;
    }
}
