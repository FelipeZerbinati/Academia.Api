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
    public class EnderecoService(IUnitOfWork unitOfWork) : IEnderecoService
    {

        public async Task<IEnumerable<Endereco>> GetAllEnderecos()
        {
            return await unitOfWork.EnderecoRepository.GetAllAsync();
        }

        public async Task<Endereco> GetByIdAsync(Guid id)
        {
            return await unitOfWork.EnderecoRepository.GetByIdAsync(id);
        }

        public async Task<Endereco> CreateEnderecoAsync(Endereco endereco)
        {
            await unitOfWork.EnderecoRepository.InsertAsync(endereco);
            await unitOfWork.CommitAsync();
            return endereco;
        }

        public async Task<Endereco> UpdateEndereco(Endereco endereco)
        {
            unitOfWork.EnderecoRepository.Update(endereco);
            await unitOfWork.CommitAsync();
            return endereco;
        }

        public async Task<bool> DeleteEndereco(Guid id)
        {
            var endereco = await unitOfWork.EnderecoRepository.GetByIdAsync(id);
            if (endereco == null) return false;

            unitOfWork.EnderecoRepository.Delete(endereco);
            await unitOfWork.CommitAsync();
            return true;
        }
    }
}
