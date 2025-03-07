using Academia.Domain.Interfaces.Service;
using Academia.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _pessoaService.GetAllPessoas());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
            return pessoa == null ? NotFound() : Ok(pessoa);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pessoa pessoa) => Ok(await _pessoaService.CreatePessoa(pessoa));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Pessoa pessoa) => Ok(await _pessoaService.UpdatePessoa(pessoa));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await _pessoaService.DeletePessoaAsync(id));
    }
}
