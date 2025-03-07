using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Service
{
    public interface IEnderecoService
    {
        Task<IEnumerable<Endereco>> GetAllEnderecos();
        Task<Endereco> GetByIdAsync(Guid id);
        Task<Endereco> CreateEnderecoAsync(Endereco endereco);
        Task<Endereco> UpdateEndereco(Endereco endereco);
        Task<bool> DeleteEndereco(Guid id);
    }
}
