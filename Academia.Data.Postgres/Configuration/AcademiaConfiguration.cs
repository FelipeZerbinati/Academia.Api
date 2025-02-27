using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using acdm = Academia.Domain.Models;
namespace Academia.Data.Postgres.Configuration;

public class AcademiaConfiguration : IEntityTypeConfiguration<acdm.Academia>
{
    public void Configure(EntityTypeBuilder<acdm.Academia> builder)
    {
        builder.ToTable("Academia");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasColumnName("Name");
        builder
            .HasMany(a => a.Aparelhos)
            .WithOne(a => a.Academia);
    }
}
