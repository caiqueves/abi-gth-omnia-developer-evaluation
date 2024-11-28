using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using Ambev.DeveloperEvaluation.Application.Event;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUser;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListUserHandler : IRequestHandler<ListUserCommand, PaginatedList<User>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly EventService _eventService;
    /// <summary>
    /// Initializes a new instance of GetUserHandler
    /// </summary>
    /// <param name="userRepository">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetUserCommand</param>
    public ListUserHandler(
        IUserRepository userRepository,
        IMapper mapper,
        EventService eventService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _eventService = eventService;
    }

    /// <summary>
    /// Handles the GetUserCommand request
    /// </summary>
    /// <param name="request">The GetUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    public async Task<PaginatedList<User>> Handle(ListUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var query = _userRepository.GetAllAsync(cancellationToken)
        .OrderBy(request.Order);

        return PaginatedList<User>.CreateAsync(query, request.Page, request.Size).Result; ;
    }
}
