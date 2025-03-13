using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Interfaces.Rest;
using Academia.Domain.Models;

namespace Academia.Data.Rest.Repository
{
    public class PessoaRepository : BaseRepository, IPessoaRepository
    {
        private const string LocationBaseUrl = "https://localhost:7213/api/Pessoa";
        public PessoaRepository() : base(LocationBaseUrl)
        {
        }

        public async Task<Pessoa> GetPessoaByIdAsync(Guid id)
        {
            return await GetAsync<Pessoa>($"/{id}");
        }

        public async Task<IEnumerable<Pessoa>> GetAllPessoas()
        {
            var pessoas = await GetAsync<List<Pessoa>>("");
            return pessoas.AsEnumerable();
        }

        public async Task<Pessoa> UpdatePessoa(Guid id, Pessoa pessoa)
        {
            return await PutAsync<Pessoa>($"/{id}", pessoa);
        }

        public async Task<Pessoa> CreatePessoa(Pessoa pessoa)
        {
            return await PostAsync<Pessoa>("", pessoa);
        }
        public async Task<Pessoa> DeletePessoaAsync(Guid id)
        {
            return await DeleteAsync<Pessoa>($"{id}");
        }
    }
}
