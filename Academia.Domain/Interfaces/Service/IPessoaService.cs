using Academia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Interfaces.Service
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GetAllPessoas();
        Task<Pessoa> GetPessoaByIdAsync(Guid id);
        Task<Pessoa> CreatePessoa(Pessoa pessoa);
        Task<Pessoa> UpdatePessoa(Pessoa pessoa);
        Task<bool> DeletePessoaAsync(Guid id);
    }
}
