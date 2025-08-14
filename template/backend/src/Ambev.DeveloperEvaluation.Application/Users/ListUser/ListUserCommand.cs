using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record ListUserCommand : IRequest<PaginatedList<User>>
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Size por page
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Order type asc / desc
    /// </summary>
    public OrderDirection Order { get; set; }

    
    public ListUserCommand(int page, int size, OrderDirection order)
    {
        Page = page;
        Size = size;
        Order = order;
    }
}
