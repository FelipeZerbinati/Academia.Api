using Contracts;
using Academia.Domain.Interfaces.Service;
using MassTransit;

namespace Academia.Application.Services.Pessoa;

public class DeletePessoaConsumer : IConsumer<IDeletePessoa>
{
    private readonly IPessoaService _pessoaService;

    public DeletePessoaConsumer(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public async Task Consume(ConsumeContext<IDeletePessoa> context)
    {
        await _pessoaService.DeletePessoaAsync(context.Message.Id);
    }
}
