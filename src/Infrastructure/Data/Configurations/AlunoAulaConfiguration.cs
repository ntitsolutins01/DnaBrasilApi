using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class AlunoAulaConfiguration : IEntityTypeConfiguration<AlunoAula>
{
    public void Configure(EntityTypeBuilder<AlunoAula> builder)
    {
        builder.Property(t => t.Progresso)
            .HasMaxLength(3);
    }
}
