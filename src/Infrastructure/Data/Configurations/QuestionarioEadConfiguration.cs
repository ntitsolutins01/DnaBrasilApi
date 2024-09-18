using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class QuestionarioEadConfiguration : IEntityTypeConfiguration<QuestaoEad>
{
    public void Configure(EntityTypeBuilder<QuestaoEad> builder)
    {
        builder.Property(t => t.Enunciado)
            .HasMaxLength(1000)
            .IsRequired();
    }
}
