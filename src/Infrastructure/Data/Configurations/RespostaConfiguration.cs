using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class RespostaConfiguration : IEntityTypeConfiguration<Resposta>
{
    public void Configure(EntityTypeBuilder<Resposta> builder)
    {
        builder.Property(t => t.RespostaQuestionario)
            .HasMaxLength(300)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(500);

        builder.Property(t => t.ValorPesoResposta).HasPrecision(10, 2);
    }
}
