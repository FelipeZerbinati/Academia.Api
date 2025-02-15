using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using acdm = Academia.Domain.Models;

namespace Academia.Data.Postgres.Configuration
{
    public class AparelhoConfiguration : IEntityTypeConfiguration<Aparelho>
    {
        public void Configure(EntityTypeBuilder<Aparelho> builder)
        {
            builder.ToTable("Aparelho");
            builder.HasKey(e => e.NomeAparelho);
            builder.HasKey(e => e.DescricaoAparelho);
        }
    }

}
