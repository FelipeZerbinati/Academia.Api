using Academia.Domain.DTO;
using Academia.Domain.Interfaces.Service;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IPublishEndpoint _publishEndpoint;

        public PessoaController(IPessoaService pessoaService, IPublishEndpoint publishEndpoint)
        {
            _pessoaService = pessoaService;
            _publishEndpoint = publishEndpoint;
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
        //public async Task<IActionResult> Post([FromBody] Pessoa pessoa) => Ok(await _pessoaService.CreatePessoa(pessoa));
        [HttpPost]
        public async Task<IActionResult> PostPessoa([FromBody] CreatePessoaDto dto)
        {
            await _publishEndpoint.Publish<ICreatePessoa>(new
            {
                dto.Nome,
                dto.DataNascimento
            });

            return Accepted();
        }


        [HttpPut("{id}")]
        //public async Task<IActionResult> Put([FromBody] Pessoa pessoa) => Ok(await _pessoaService.UpdatePessoa(pessoa));
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePessoaDto dto)
        {
            await _publishEndpoint.Publish<IUpdatePessoa>(new
            {
                Id = id,
                dto.Nome,
                dto.DataNascimento
            });

            return Accepted();
        }

        [HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id) => Ok(await _pessoaService.DeletePessoaAsync(id));
        public async Task<IActionResult> Delete(Guid id)
        {
            await _publishEndpoint.Publish<IDeletePessoa>(new
            {
                Id = id
            });

            return Accepted();
        }

    }
}
