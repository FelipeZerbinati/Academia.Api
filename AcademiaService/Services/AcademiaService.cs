using Academia.Domain.DTO;
using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Interfaces.Service;
using Academia.Domain.Models;
using acdm = Academia.Domain.Models;

namespace Academia.Application.Services;

public class AcademiaService(IUnitOfWork unitOfWork) : IAcademiaService
{


    public async Task<ResultData<acdm.Academia>> AddAcademia(Domain.Models.Academia academia)
    {
        var result = new ResultData<acdm.Academia>();
        try
        {
            if (academia == null)
            {
                result.Success = false;
                result.ErrorDescription = "Academia não pode ser nulo.";
                return result;
            }
            var id = unitOfWork.AcademiaRepository.Insert(academia);
            academia.Id = id;
            await unitOfWork.CommitAsync();
            result.Success = true;
            result.Data = academia;
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
                result.Data = null;
            }
        }
        return result;
    }

    public async Task<ResultData<bool>> DeleteAcademia(Guid academiaId)
    {
        var result = new ResultData<bool>();
        try
        {
            var academia = await unitOfWork.AcademiaRepository.GetAsync(false, null, a => a.Id == academiaId);
            unitOfWork.AcademiaRepository.Delete(academia);
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

    public async Task<ResultData<Domain.Models.Academia>> GetAcademiaById(Guid id)
    {
        var result = new ResultData<acdm.Academia>();
        try
        {
            var academia = await unitOfWork.AcademiaRepository.GetAsync(false, null, a => a.Id == id);
            result.Success = true;
            result.Data = academia;
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
                result.Data = new acdm.Academia();
            }
        }
        return result;
    }

    public async Task<ResultData<List<acdm.Academia>>> GetAcademias()
    {
        var result = new ResultData<List<acdm.Academia>>();
        try
        {
            var academia = await unitOfWork.AcademiaRepository.GetAllAsync();
            result.Success = true;
            result.Data = academia;
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
                result.Data = new List<acdm.Academia>();
            }
        }
        return result;
    }

    public async Task<ResultData<acdm.Academia>> UpdateAcademia(Guid id, Domain.Models.Academia updatedAcademia)
    {
        var result = new ResultData<acdm.Academia>();
        try
        {

            var academia = await unitOfWork.AcademiaRepository.GetAsync(false, null, a => a.Id == id);

            if (academia == null)
            {
                result.Success = false;
                result.ErrorDescription = "Gym does not exists.";
                return result;
            }

            academia.Name = updatedAcademia.Name;
            unitOfWork.AcademiaRepository.Update(academia);
            await unitOfWork.CommitAsync();
            result.Success = true;
            result.Data = academia;
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
                result.Success= false;
            }
        }

        return result;
    }
}


