using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class TextoImagemQuestaoConfiguration : IEntityTypeConfiguration<TextoImagemQuestao>
{
    public void Configure(EntityTypeBuilder<TextoImagemQuestao> builder)
    {
        builder.Property(t => t.TextoImagem).HasMaxLength(1000);
        builder.Property(t => t.Tipo).HasMaxLength(1);
    }
}
