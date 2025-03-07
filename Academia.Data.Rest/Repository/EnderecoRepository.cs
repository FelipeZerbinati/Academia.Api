using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Academia.Data.Rest.Repository
{
    public class EnderecoRepository : BaseRepository
    {
        private const string LocationBaseUrl = "https://localhost:7213/api/Endereco";
        public EnderecoRepository() : base(LocationBaseUrl)
        {
        }

        public async Task<Endereco> GetByIdAsync(Guid id)
        {
            return await GetAsync<Endereco>($"/{id}");
        }

        public async Task<IEnumerable<Endereco>> GetAllEnderecos()
        {
            var enderecos = await GetAsync<List<Endereco>>("");
            return enderecos.AsEnumerable();
        }

        public async Task<Endereco> CreateEnderecoAsync(Endereco endereco)
        {
            return await PostAsync<Endereco>("", endereco);
        }

        public async Task<Endereco> UpdateEndereco(Guid id, Endereco endereco)
        {
            return await PutAsync<Endereco>($"/{id}", endereco);
        }

        public async Task<Endereco> DeleteEndereco(Guid id)
        {
            return await DeleteAsync<Endereco>($"/{id}");
        }
    }
}
