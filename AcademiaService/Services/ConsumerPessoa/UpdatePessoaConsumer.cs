using Academia.Domain.Interfaces.Service;
using acdm = Academia.Domain.Models;
using MassTransit;
using Contracts;

namespace Academia.Application.Services.Pessoa;

public class UpdatePessoaConsumer : IConsumer<IUpdatePessoa>
{
    private readonly IPessoaService _pessoaService;

    public UpdatePessoaConsumer(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public async Task Consume(ConsumeContext<IUpdatePessoa> context)
    {
        var pessoa = new acdm.Pessoa
        {
            Id = context.Message.Id,
            Nome = context.Message.Nome,
            DataNascimento = context.Message.DataNascimento
        };
        pessoa.Update();

        await _pessoaService.UpdatePessoa(pessoa);
    }
}

