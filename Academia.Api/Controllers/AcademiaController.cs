using Academia.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using acdm = Academia.Domain.Models;

namespace Academia.Api.Controllers;
[Route("api/[controller]")]
public class AcademiaController : ControllerBase
{
    private readonly IAcademiaService _academiaService;
    public AcademiaController(IAcademiaService academiaService)
    {
        _academiaService = academiaService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAcademiaById(Guid id)
    {
        var result = await _academiaService.GetAcademiaById(id);
        if (!result.Success)
        {
            return NotFound();
        }
        return Ok(result.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAcademias()
    {
        var result = await _academiaService.GetAcademias();
        if (!result.Success)
        {
            return NotFound();
        }
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> AddAcademia([FromBody] acdm.Academia newAcademia)
    {
        if (newAcademia == null)
        {
            return BadRequest("Academia data não pode ser nulo.");
        }
        var result = await _academiaService.AddAcademia(newAcademia);
        if (!result.Success)
        {
            return BadRequest(result.ErrorDescription);
        }
        return Ok(result.Data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAcademia(Guid id, [FromBody] acdm.Academia updatedAcademia)
    {
        if (id != updatedAcademia.Id)
        {
            return BadRequest("Academia Id incompativel");
        }
        var result = await _academiaService.UpdateAcademia(id, updatedAcademia);
        if (!result.Success)
        {
            return NotFound(result.ErrorDescription);
        }
        return Ok(result.Data);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAcademia(Guid id)
    {
        var result = await _academiaService.DeleteAcademia(id);
        if (!result.Success)
        {
            return NotFound(result.ErrorDescription);
        }
        return Accepted();
    }
}
