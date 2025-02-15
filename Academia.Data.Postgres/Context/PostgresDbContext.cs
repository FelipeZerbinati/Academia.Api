﻿using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using acdm = Academia.Domain.Models;
namespace Academia.Data.Postgres.Context;

public class PostgresDbContext : DbContext
{
    public DbSet<acdm.Academia> Academia { get; set; }
    public DbSet<Aparelho> Aparelho { get; set; }
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // Use o diretório base do projeto
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DatabasePostGres");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("A conexão com o banco de dados não foi configurada corretamente.");
            }

            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<acdm.Academia>(entity =>
        {
        });

        modelBuilder.Entity<Aparelho>(entity =>
        {
            entity.HasKey(a => a.ID);  // Define a chave primária
            entity.Property(a => a.NomeAparelho).IsRequired();
            entity.Property(a => a.DescricaoAparelho).IsRequired();
        });
    }
}
