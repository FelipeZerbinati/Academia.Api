using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;
using acdm = Academia.Domain.Models;
namespace Academia.Data.Postgres.Context;

public class PostgresDbContext : DbContext
{
    public DbSet<acdm.Academia> Academia { get; set; }
    public DbSet<Aparelho> Aparelho { get; set; }
    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
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
}