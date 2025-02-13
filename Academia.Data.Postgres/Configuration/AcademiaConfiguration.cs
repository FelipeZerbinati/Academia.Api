using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using acdm = Academia.Domain.Models;
namespace Academia.Data.Postgres.Configuration;

public class AcademiaConfiguration : IEntityTypeConfiguration<acdm.Academia>
{
    public void Configure(EntityTypeBuilder<acdm.Academia> builder)
    {
        builder.ToTable("Academia");
        builder.HasKey(e => e.ID);
        builder.HasKey(e => e.Nome);
        builder.HasKey(e => e.AnoFundacao);
    }
}
