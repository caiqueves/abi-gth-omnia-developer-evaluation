namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategory;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class ListProductCategoryRequest
{
    public int Page { get; set; } = 1;

    /// <summary>
    /// Size por page
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// Order type asc / desc
    /// </summary>
    public string Order { get; set; } = "CreateAt";

    public string Category { get; set; } = string.Empty;

    public ListProductCategoryRequest( int page, int size, string order, string category)
    {
        Page = page;
        Size = size;
        Order = order;
        Category = category;
    }
}
