using System.Net;
using Microsoft.AspNetCore.Http;
using Schedule.Domain.Models;
using Schedule.Domain.Repositories;
using Schedule.Domain.Responses;

namespace Schedule.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task<Result<Object>>Save(UserModel model)
    {
        bool isSaved = (_userRepository.CreateAsync(model))!=null;
        if (isSaved)
            return Task.FromResult<Result<object>>(Result<object>.Success(new {}, HttpStatusCode.Created));
        
        return Task.FromResult<Result<object>>(Result<object>.Failure(new List<string> { "Error al guardar el usuario." }, HttpStatusCode.BadRequest));
    }
}