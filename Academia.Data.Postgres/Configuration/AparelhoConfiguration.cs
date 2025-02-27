using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using acdm = Academia.Domain.Models;

namespace Academia.Data.Postgres.Configuration
{
    public class AparelhoConfiguration : IEntityTypeConfiguration<Aparelho>
    {
        public void Configure(EntityTypeBuilder<Aparelho> builder)
        {
            builder.ToTable("Aparelho");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Name).HasColumnName("Name");
            builder
            .HasOne(e => e.Academia)
            .WithMany(a => a.Aparelhos);
        }
    }

}
