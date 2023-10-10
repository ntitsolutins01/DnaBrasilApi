using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;

internal class AlunoMatriculasConfiguration : IEntityTypeConfiguration<AlunoMatriculas>
{
    public void Configure(EntityTypeBuilder<AlunoMatriculas> builder)
    {
        builder.Property(t => t.NomePrimResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.ParentescoPrimResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.CpfPrimResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.NomeSegResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.ParentescoSegResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.CpfSegResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.NomeTerResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.ParentescoTerResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.CpfTerResponsavel)
            .HasMaxLength(80)
            .IsRequired();
        builder.Property(t => t.DtVencAtestadoMedico)
            .IsRequired();
        builder.Property(t => t.DtVencPARQ)
            .IsRequired();
    }
}
