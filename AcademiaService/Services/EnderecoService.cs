using Academia.Domain.Interfaces.Rest;
using Academia.Domain.Interfaces.Service;
using Academia.Domain.Models;

public class EnderecoService : IEnderecoService
{
    private readonly IEnderecoRepository _enderecoRepository;

    public EnderecoService(IEnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public async Task<IEnumerable<Endereco>> GetAllEnderecos()
    {
        return await _enderecoRepository.GetAllEnderecos();
    }

    public async Task<Endereco> GetByIdAsync(Guid id)
    {
        return await _enderecoRepository.GetByIdAsync(id);
    }

    public async Task<Endereco> CreateEnderecoAsync(Endereco endereco)
    {
        await _enderecoRepository.CreateEnderecoAsync(endereco);
        return endereco;
    }

    public async Task<Endereco> UpdateEndereco(Guid id, Endereco endereco)
    {
        await _enderecoRepository.UpdateEndereco(endereco.Id, endereco);
        return endereco;
    }

    public async Task<bool> DeleteEndereco(Guid id)
    {
        var endereco = await _enderecoRepository.DeleteEndereco(id);
        return endereco != null;
    }
}
