using BirdAPI.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BirdAPI.ApiService.Controllers;

[ApiController]
[Route("xc")]
public class XenoCantoEntryController(IXenoCantoEntriyRepository mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetXenoCantoEntry(string id)
    {
        var entry = await mediator.GetXenoCantoEntryByIdAsync(id, CancellationToken.None);
        return Ok(entry);
    }

}