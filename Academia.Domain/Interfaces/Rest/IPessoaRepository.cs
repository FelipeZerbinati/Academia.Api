using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Rest
{
    public interface IPessoaRepository
    {
        Task<Pessoa> GetPessoaByIdAsync(Guid id);
        Task<IEnumerable<Pessoa>> GetAllPessoas();
        Task<Pessoa> UpdatePessoa(Guid id, Pessoa pessoa);
        Task<Pessoa> CreatePessoa(Pessoa pessoa);
        Task<bool> DeletePessoaAsync(Guid id);
    }
}
