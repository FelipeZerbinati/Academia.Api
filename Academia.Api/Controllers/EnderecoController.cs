using Academia.Domain.Interfaces.Service;
using Academia.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var enderecos = await _enderecoService.GetAllEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var endereco = await _enderecoService.GetByIdAsync(id);
            return endereco == null ? NotFound() : Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Endereco endereco)
        {
            if (endereco == null)
                return BadRequest("Dados inválidos.");

            var novoEndereco = await _enderecoService.CreateEnderecoAsync(endereco);
            return CreatedAtAction(nameof(Get), new { id = novoEndereco.Id }, novoEndereco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Endereco endereco)
        {
            if (endereco == null || endereco.Id != id)
                return BadRequest("Dados inválidos.");

            var enderecoAtualizado = await _enderecoService.UpdateEndereco(endereco.Id, endereco);
            return Ok(enderecoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucesso = await _enderecoService.DeleteEndereco(id);
            return sucesso ? NoContent() : NotFound();
        }
    }
}
