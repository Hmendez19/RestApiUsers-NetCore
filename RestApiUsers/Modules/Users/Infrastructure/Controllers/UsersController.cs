using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestApiUsers.Common.Exceptions.Custom;
using RestApiUsers.Common.Exceptions.Handler;
using RestApiUsers.Modules.Users.Domain.Dto;
using RestApiUsers.Modules.Users.Domain.Entities;
using RestApiUsers.Modules.Users.Domain.Exceptions;
using RestApiUsers.Modules.Users.Infrastructure.Services;

namespace RestApiUsers.Modules.Users.Infrastructure.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController: ControllerBase
{
    private readonly UserService _userService = new UserService();

    [HttpGet]
    public Task<IEnumerable<UserEntity>> GetAll()
    {
        return Task.FromResult(_userService.GetAll());
    }

    [HttpPost]
    public Task<IActionResult> Create([FromBody] UserDto user)
    {
        try
        {
            _userService.SaveUser(user);
            return Task.FromResult<IActionResult>(new ObjectResult(new
            {
                message = "El usuario se ha registrado correctamente"
            }) { StatusCode = StatusCodes.Status201Created });
        }
        catch (NotValidException ex)
        {
            return CustomHandleException.Handle(ex, StatusCodes.Status400BadRequest);
        }
        catch (ConflictException ex)
        {
            return CustomHandleException.Handle(ex, StatusCodes.Status409Conflict);
        }
        catch (Exception ex)
        {
            return Task.FromResult<IActionResult>(StatusCode(StatusCodes.Status500InternalServerError,ex.Message));
        }
    }
}