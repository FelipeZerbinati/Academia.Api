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
    public async Task<IActionResult> GetAparelhoById(Guid id)
    {
        var result = await _aparelhoService.GetAparelhoById(id);
        if (!result.Success)
        {
            return NotFound();
        }
        return Ok(result.Data);
    }

    [HttpGet("{page}/{perPage}")]
    public async Task<IActionResult> GetAparelhos(int page, int perPage)
    {
        var result = await _aparelhoService.GetAparelhos(page, perPage);
        if (!result.Success)
        {
            return NotFound();
        }
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> AddAparelho([FromBody] Aparelho newAparelho)
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
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAparelho(Guid id, [FromBody] Aparelho updatedAparelho)
    {
        if (id != updatedAparelho.Id)
        {
            return BadRequest("Aparelho Id incompativel");
        }
        var result = await _aparelhoService.UpdateAparelho(id, updatedAparelho);
        if (!result.Success)
        {
            return NotFound(result.ErrorDescription);
        }
        return Ok(result.Data);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAparelho(Guid id)
    {
        var result = await _aparelhoService.DeleteAparelho(id);
        if (!result.Success)
        {
            return NotFound(result.ErrorDescription);
        }
        return Accepted();
    }
}
