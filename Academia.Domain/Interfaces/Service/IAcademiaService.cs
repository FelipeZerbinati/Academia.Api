﻿using Academia.Domain.DTO;
using acdm = Academia.Domain.Models;
namespace Academia.Domain.Interfaces.Service;

public interface IAcademiaService
{
    Task<ResultData<bool>> AddAcademia(acdm.Academia academia);
    Task<ResultData<acdm.Academia>> GetAcademiaById(Guid id);
    Task<ResultData<bool>> UpdateAcademia(Guid id, acdm.Academia updatedAcademia);
    Task<ResultData<bool>> DeleteAcademia(Guid academiaId);
}
