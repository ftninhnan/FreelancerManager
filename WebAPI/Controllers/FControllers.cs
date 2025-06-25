using Application.Database;
using Application.Interfaces;
using Domain.Information;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FController : ControllerBase
{
    private readonly IFFreelanceService _service;

    public FController(IFFreelanceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetById(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FreelancerData data)
    {
        var created = await _service.Create(data);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] FreelancerData data)
    {
        try
        {
            await _service.Update(id, data);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message); // or return BadRequest(ex.Message)
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);
        return NoContent();
    }

    [HttpPatch("{id}/archive")]
    public async Task<IActionResult> Archive(Guid id)
    {
        await _service.Archive(id);
        return NoContent();
    }

    [HttpPatch("{id}/unarchive")]
    public async Task<IActionResult> Unarchive(Guid id)
    {
        await _service.Unarchive(id);
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string wildcard)
    {
        var result = await _service.Search(wildcard);
        return Ok(result);
    }
}