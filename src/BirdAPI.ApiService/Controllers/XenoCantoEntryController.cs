using System.Diagnostics;
using System.Threading.Tasks;
using BirdAPI.ApiService.Commands;
using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;
using Bogus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BirdAPI.ApiService.Controllers;

[ApiController]
[Route("xc")]
public class XenoCantoEntryController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id) => Ok(await mediator.Send(new GetXenoCantoItemByIdQuery { Id = id }));

}