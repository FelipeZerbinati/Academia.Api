using Academia.Domain.DTO;
using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Interfaces.Service;
using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Application.Services
{
    public class Aparelhoservice(IUnitOfWork unitOfWork) : IAparelhoService
    {
        public async Task<ResultData<bool>> AddAparelho(Aparelho aparelho)
        {
            var result = new ResultData<bool>();
            try
            {
                if (aparelho == null)
                {
                    result.Success = false;
                    result.ErrorDescription = "Aparelho não pode ser nulo.";
                    return result;
                }
                unitOfWork.AparelhoRepository.Insert(aparelho);
                await unitOfWork.CommitAsync();
                result.Success = true;
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorDescription = $"Erro inesperado: {ex.Message}";
            }
            finally
            {
                if (!result.Success)
                {
                    result.Data = false;
                }
            }
            return result;
        }

        public async Task<ResultData<bool>> DeleteAparelho(Guid aparelhoId)
        {
            var result = new ResultData<bool>();
            try
            {
                var aparelho = await unitOfWork.AparelhoRepository.GetAsync(false, null, a => a.Id == aparelhoId);
                unitOfWork.AparelhoRepository.Delete(aparelho);
                await unitOfWork.CommitAsync();
                result.Success = true;
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorDescription = $"Erro inesperado: {ex.Message}";
            }
            finally
            {
                if (!result.Success)
                {
                    result.Data = false;
                }
            }
            return result;
        }

        public async Task<ResultData<Aparelho>> GetAparelhoById(Guid id)
        {
            var result = new ResultData<Aparelho>();
            try
            {
                var aparelho = await unitOfWork.AparelhoRepository.GetAsync(false, null, a => a.Id == id);
                result.Success = true;
                result.Data = aparelho;
            }
            catch (Exception ex)
            {
                result.ErrorDescription = $"Erro inesperado: {ex.Message}";
                result.Success = false;
            }

            finally
            {
                if (!result.Success)
                {
                    result.Data = new Aparelho();
                }
            }
            return result;
        }

        public async Task<ResultData<List<Aparelho>>> GetAparelhos()
        {
            var result = new ResultData<List<Aparelho>>();
            try
            {
                var aparelho = await unitOfWork.AparelhoRepository.GetAllAsync();
                result.Success = true;
                result.Data = aparelho;
            }
            catch (Exception ex)
            {
                result.ErrorDescription = $"Erro inesperado: {ex.Message}";
                result.Success = false;
            }

            finally
            {
                if (!result.Success)
                {
                    result.Data = new List<Aparelho>();
                }
            }
            return result;
        }

        public async Task<ResultData<Aparelho>> UpdateAparelho(Guid id, Aparelho updatedAparelho)
        {
            var result = new ResultData<Aparelho>();
            try
            {
                var aparelho = await unitOfWork.AparelhoRepository.CountAsync(a => a.Id == id);
                if (aparelho == 0)
                {
                    result.Success = false;
                    result.ErrorDescription = "Gym equipment does not exists.";
                    return result;
                }
                unitOfWork.AparelhoRepository.Update(updatedAparelho);
                await unitOfWork.CommitAsync();
                result.Success = true;
                result.Data = updatedAparelho;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorDescription = $"Erro inesperado: {ex.Message}";
            }
            finally
            {
                if (!result.Success)
                {
                    result.Success = false;
                }
            }
            return result;
        }
    }
}
