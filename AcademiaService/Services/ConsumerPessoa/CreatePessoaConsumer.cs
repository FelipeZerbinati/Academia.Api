using Academia.Domain.Interfaces.Service;
using Contracts;
using MassTransit;

namespace Academia.Application.Services.Pessoa;

public class CreatePessoaConsumer : IConsumer<ICreatePessoa>
{
    private readonly IPessoaService _pessoaService;

    public CreatePessoaConsumer(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public async Task Consume(ConsumeContext<ICreatePessoa> context)
    {
        var message = context.Message;

        var novaPessoa = new Domain.Models.Pessoa
        {
            Nome = message.Nome,
            DataNascimento = message.DataNascimento
        };

        novaPessoa.Create();

        await _pessoaService.CreatePessoa(novaPessoa);
    }
}
