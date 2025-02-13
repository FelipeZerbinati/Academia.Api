using acdm = Academia.Domain.Models;
using IPostgres = Academia.Domain.Interfaces.Postgres;
namespace Academia.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IPostgres.IRepositoryBase<acdm.Academia> AcademiaRepository { get; }
        Task<bool> CommitAsync();
    }
}
