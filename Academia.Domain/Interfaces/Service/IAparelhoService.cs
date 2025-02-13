using Academia.Domain.DTO;
using Academia.Domain.Models;


namespace Academia.Domain.Interfaces.Service
{
    public interface IAparelhoService
    {
        Task<ResultData<bool>> AddAparelho(Aparelho aparelho);
        Task<ResultData<Aparelho>> GetAparelhoById(int id);
        Task<ResultData<bool>> UpdateAparelho(int id, Aparelho updatedAparelho);
        Task<ResultData<bool>> DeleteAparelho(int aparelhoId);
    }
}
