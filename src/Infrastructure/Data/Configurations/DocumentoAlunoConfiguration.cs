using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class DocumentoAlunoConfiguration : IEntityTypeConfiguration<DocumentoAluno>
{
    public void Configure(EntityTypeBuilder<DocumentoAluno> builder)
    {
        builder.Property(t => t.NomeDocumento)
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(t => t.Url)
            .HasMaxLength(500);
    }
}
