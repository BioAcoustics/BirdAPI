using System.Diagnostics;
using BirdAPI.ApiService.Commands;
using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;
using Bogus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BirdAPI.ApiService.Controllers;

[ApiController]
[Route("users")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost("create/fake")]
    public async Task<IActionResult> AddFakeUsers(AddFakeUsersCommand command)=> Ok(await mediator.Send(command));
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(AddUserCommand command)=> Ok(await mediator.Send(command));

}