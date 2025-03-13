using Academia.Domain.Interfaces.Rest;
using Academia.Domain.Interfaces.Service;
using Academia.Domain.Models;

public class PessoaService : IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public async Task<IEnumerable<Pessoa>> GetAllPessoas()
    {
        return await _pessoaRepository.GetAllPessoas();
    }

    public async Task<Pessoa> GetPessoaByIdAsync(Guid id)
    {
        return await _pessoaRepository.GetPessoaByIdAsync(id);
    }

    public async Task<Pessoa> CreatePessoa(Pessoa pessoa)
    {
        foreach (var pessoaEndereco in pessoa.PessoasEnderecos)
        {
            pessoaEndereco.PessoaId = pessoa.Id;
        }

        await _pessoaRepository.CreatePessoa(pessoa);
        return pessoa;
    }

    public async Task<Pessoa> UpdatePessoa(Pessoa pessoa)
    {
        return await _pessoaRepository.UpdatePessoa(pessoa.Id, pessoa);
    }

    public async Task<bool> DeletePessoaAsync(Guid id)
    {
        var pessoa = await _pessoaRepository.DeletePessoaAsync(id);
        return pessoa != null;
    }
}
