using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class TextoQuestaoConfiguration : IEntityTypeConfiguration<TextoImagemQuestao>
{
    public void Configure(EntityTypeBuilder<TextoImagemQuestao> builder)
    {
        builder.Property(t => t.TextoImagem).HasMaxLength(1000);
    }
}
