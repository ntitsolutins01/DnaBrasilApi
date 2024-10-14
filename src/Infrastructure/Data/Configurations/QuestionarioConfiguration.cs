using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class QuestionarioConfiguration : IEntityTypeConfiguration<Questionario>
{
    public void Configure(EntityTypeBuilder<Questionario> builder)
    {
        builder.Property(t => t.Pergunta)
            .HasMaxLength(400)
            .IsRequired();
    }
}
