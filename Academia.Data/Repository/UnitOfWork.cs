﻿using Academia.Data.Postgres.Context;
using Academia.Data.Postgres.Repository;
using Academia.Domain.Interfaces.Postgres;
using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Models;
using acdm = Academia.Domain.Models;

namespace Academia.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        //contexts
        private readonly PostgresDbContext _postgresContext;
        //repositorys
        private IRepositoryBase<acdm.Academia>? _academiaRepository;
        private IRepositoryBase<Aparelho>? _aparelhoRepository;
        private IRepositoryBase<Pessoa>? _pessoaRepository;
        private IRepositoryBase<Endereco>? _enderecoRepository;

        public UnitOfWork(
PostgresDbContext postgresContext)
        {
            //constructor
            _postgresContext = postgresContext;
            //repositoryInject

        }

        //injections
        public IRepositoryBase<acdm.Academia> AcademiaRepository => _academiaRepository ?? (_academiaRepository = new RepositoryBase<acdm.Academia>(_postgresContext));

        public IRepositoryBase<Aparelho> AparelhoRepository => _aparelhoRepository ?? (_aparelhoRepository = new RepositoryBase<Aparelho>(_postgresContext));
        public IRepositoryBase<Pessoa> PessoaRepository => _pessoaRepository ?? (_pessoaRepository = new RepositoryBase<Pessoa>(_postgresContext));
        public IRepositoryBase<Endereco> EnderecoRepository => _enderecoRepository ?? (_enderecoRepository = new RepositoryBase<Endereco>(_postgresContext));
                     

        public async Task<bool> CommitAsync() 
        {
            return await _postgresContext.SaveChangesAsync() > 0;
        }
    }
}
