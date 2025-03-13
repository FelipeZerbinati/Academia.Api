using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Rest
{
    public interface IEnderecoRepository
    {
        Task<Endereco> GetByIdAsync(Guid id);
        Task<IEnumerable<Endereco>> GetAllEnderecos();
        Task<Endereco> CreateEnderecoAsync(Endereco endereco);
        Task<Endereco> UpdateEndereco(Guid id, Endereco endereco);
        Task<Endereco> DeleteEndereco(Guid id);
    }
}
