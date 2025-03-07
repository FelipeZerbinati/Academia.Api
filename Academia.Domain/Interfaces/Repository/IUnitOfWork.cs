using Academia.Domain.Interfaces.Postgres;
using Academia.Domain.Models;
using acdm = Academia.Domain.Models;
namespace Academia.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IRepositoryBase<acdm.Academia> AcademiaRepository { get; }

        IRepositoryBase<Aparelho> AparelhoRepository { get; }

        IRepositoryBase<Pessoa> PessoaRepository { get; }
        IRepositoryBase<Endereco> EnderecoRepository { get; }
        Task<bool> CommitAsync();
    }
}
