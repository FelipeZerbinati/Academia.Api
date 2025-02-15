using Academia.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Academia.Domain.Models;
using Academia.Application.Services;

namespace Academia.Api.Controllers;
[Route("api/[controller]")]
public class AparelhosController : ControllerBase
{
    private readonly IAparelhoService _aparelhoService;
    public AparelhosController(IAparelhoService aparelhoService)
    {
        _aparelhoService = aparelhoService;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Aparelho>> GetAparelhoById(Guid id)
    {
        var result = await _aparelhoService.GetAparelhoById(id);
        if (!result.Success)
        {
            return NotFound();
        }
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<ActionResult<Aparelho>> AddAparelho([FromBody] Aparelho newAparelho)
    {
        if (newAparelho == null)
        {
            return BadRequest("Aparelho data não pode ser nulo.");
        }
        var result = await _aparelhoService.AddAparelho(newAparelho);
        if (!result.Success)
        {
            return BadRequest(result.ErrorDescription);
        }
        return CreatedAtAction(nameof(GetAparelhoById), new { id = newAparelho.ID }, newAparelho);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAparelho(Guid id, [FromBody] Aparelho updatedAparelho)
    {
        if (id != updatedAparelho.ID)
        {
            return BadRequest("Aparelho Id incompativel");
        }
        var result = await _aparelhoService.UpdateAparelho(id, updatedAparelho);
        if (!result.Success)
        {
            return NotFound(result.ErrorDescription);
        }
        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAparelho(Guid id)
    {
        var result = await _aparelhoService.DeleteAparelho(id);
        if (!result.Success)
        {
            return NotFound(result.ErrorDescription);
        }
        return NoContent();
    }
}
