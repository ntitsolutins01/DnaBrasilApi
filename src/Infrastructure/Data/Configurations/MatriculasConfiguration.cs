using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

internal class MatriculasConfiguration : IEntityTypeConfiguration<MatriculaOld>
{
    public void Configure(EntityTypeBuilder<MatriculaOld> builder)
    {
        //    builder.Property(t => t.NomeResponsavel1)
        //        .HasMaxLength(150);
        //    builder.Property(t => t.ParentescoResponsavel1)
        //        .HasMaxLength(10);
        //    builder.Property(t => t.CpfResponsavel1)
        //        .HasMaxLength(14);
        //    builder.Property(t => t.NomeResponsavel2)
        //        .HasMaxLength(150);
        //    builder.Property(t => t.ParentescoResponsavel2)
        //        .HasMaxLength(10);
        //    builder.Property(t => t.CpfResponsavel2)
        //        .HasMaxLength(14);
        //    builder.Property(t => t.NomeResponsavel3)
        //        .HasMaxLength(150);
        //    builder.Property(t => t.ParentescoResponsavel3)
        //        .HasMaxLength(10);
        //    builder.Property(t => t.CpfResponsavel3)
        //        .HasMaxLength(14);
        //    builder.Property(t => t.DtVencimentoParq);
        //    builder.Property(t => t.DtVencimentoAtestadoMedico);

    }
}
