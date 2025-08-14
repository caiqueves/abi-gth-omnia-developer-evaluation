using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;


public record ListUserResponse
{
    public List<User>? Data { get; set; } 
    public int TotalItems { get; set; }  
    public int CurrentPage { get; set; } 
    public int TotalPages { get; set; }  

}
