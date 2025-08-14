using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class ListUserResult
{
    public List<User>? Users { get; set; }
}
