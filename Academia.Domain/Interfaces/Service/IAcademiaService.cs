using Academia.Domain.DTO;
using acdm = Academia.Domain.Models;
namespace Academia.Domain.Interfaces.Service;

public interface IAcademiaService
{
    Task<ResultData<acdm.Academia>> AddAcademia(acdm.Academia academia);
    Task<ResultData<acdm.Academia>> GetAcademiaById(Guid id);
    Task<ResultData<List<acdm.Academia>>> GetAcademias(int page, int perPage);
    Task<ResultData<acdm.Academia>> UpdateAcademia(Guid id, acdm.Academia updatedAcademia);
    Task<ResultData<bool>> DeleteAcademia(Guid academiaId);
}
