using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class TextoQuestaoConfiguration : IEntityTypeConfiguration<TextoQuestao>
{
    public void Configure(EntityTypeBuilder<TextoQuestao> builder)
    {
        builder.Property(t => t.Texto).HasMaxLength(1000);
    }
}
