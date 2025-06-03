using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class AlunoAulaConfiguration : IEntityTypeConfiguration<AlunoAula>
{
    public void Configure(EntityTypeBuilder<AlunoAula> builder)
    {
        builder.Property(t => t.Progresso)
            .HasMaxLength(3);
    }
}
