using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetUserResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created user.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created user in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string PassWord { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public Address? Address { get; set; }

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The current status of the user
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public string Role { get; set; } = string.Empty;
}
