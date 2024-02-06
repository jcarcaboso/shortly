using System.Security.Cryptography;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shortly.App.AddMapping;
using Shortly.App.GetKey;
using Shortly.App.GetMapping;

namespace Shorty.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MappingController(IMediator _mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<string> Get(string id, CancellationToken ct)
    {
        var rs = await _mediator.Send(new GetMappingQuery(id), ct);

        return rs.DestinationUrl;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<string>>> GetAll(CancellationToken ct)
    {
        var rs = await _mediator.Send(new GetAllMappingsQuery(), ct);

        return Ok(rs.Mappings);
    }

    [HttpPost]
    public async Task<ActionResult<string>> Add(string url, CancellationToken ct)
    {
        var key = await _mediator.Send(new GetKeyQuery(), ct);

        await _mediator.Send(new AddMappingCommand(key, url), ct);

        return key;
    }

    [HttpPut("toggle/{id}")]
    public async Task<IActionResult> Toggle(string id)
    {
        return NoContent();
    }
}
