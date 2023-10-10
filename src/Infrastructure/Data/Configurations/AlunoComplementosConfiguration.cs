using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class AlunoComplementosConfiguration : IEntityTypeConfiguration<AlunoComplementos>
{
    public void Configure(EntityTypeBuilder<AlunoComplementos> builder)
    {
        builder.Property(t => t.Doencas)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(t => t.Nacionalidade)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Naturalidade)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.NomeEscola)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.Serie)
            .HasMaxLength(15)
            .IsRequired();
        builder.Property(t => t.Ano)
            .HasMaxLength(15)
            .IsRequired();
        builder.Property(t => t.Turma)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(t => t.AutSaida)
            .IsRequired();
        builder.Property(t => t.TermoCompromisso)
            .IsRequired();
        builder.Property(t => t.AutCapitacaoEUsoDeIndicadoresDeSaude)
            .IsRequired();
    }
}
