using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using acdm = Academia.Domain.Models;
namespace Academia.Data.Postgres.Context;

public class PostgresDbContext : DbContext
{
    public DbSet<acdm.Academia> Academia { get; set; }
    public DbSet<Aparelho> Aparelho { get; set; }
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }
    private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=@Postgre03;Database=Academia";

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

            var connectionString = configuration.GetConnectionString("DefaultConnection");

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

        });
    }
}
