using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Interfaces.Service;
using Academia.Domain.Models;

namespace Academia.Application.Services;

public class PessoaService(IUnitOfWork unitOfWork) : IPessoaService
{

    public async Task<IEnumerable<Pessoa>> GetAllPessoas()
    {
        return await unitOfWork.PessoaRepository.GetAllAsync();
    }

    public async Task<Pessoa> GetPessoaByIdAsync(Guid id)
    {
        return await unitOfWork.PessoaRepository.GetByIdAsync(id);
    }

    public async Task<Pessoa> CreatePessoa(Pessoa pessoa)
    {
        foreach (var pessoaEndereco in pessoa.PessoasEnderecos)
        {
            pessoaEndereco.PessoaId = pessoa.Id;
        }

        await unitOfWork.PessoaRepository.InsertAsync(pessoa);
        await unitOfWork.CommitAsync();
        return pessoa;
    }



    public async Task<Pessoa> UpdatePessoa(Pessoa pessoa)
    {
        unitOfWork.PessoaRepository.Update(pessoa);
        await unitOfWork.CommitAsync();
        return pessoa;
    }

    public async Task<bool> DeletePessoaAsync(Guid id)
    {
        var pessoa = await unitOfWork.PessoaRepository.GetByIdAsync(id);
        if (pessoa == null) return false;

        unitOfWork.PessoaRepository.Delete(pessoa);
        await unitOfWork.CommitAsync();
        return true;
    }
}
