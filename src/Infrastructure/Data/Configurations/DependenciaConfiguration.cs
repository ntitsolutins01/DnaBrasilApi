﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
internal class DependenciaConfiguration : IEntityTypeConfiguration<Dependencia>
{
    public void Configure(EntityTypeBuilder<Dependencia> builder)
    {
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();
        builder.Property(t => t.Doencas)
            .HasMaxLength(400);
        builder.Property(t => t.Nacionalidade)
            .HasMaxLength(50);
        builder.Property(t => t.TipoEscolaridade)
            .HasMaxLength(50);
        builder.Property(t => t.TipoEscola)
            .HasMaxLength(50);
        builder.Property(t => t.Naturalidade)
            .HasMaxLength(50);
        builder.Property(t => t.NomeEscola)
            .HasMaxLength(150);
        builder.Property(t => t.Turno)
            .HasMaxLength(1);
        builder.Property(t => t.Serie)
            .HasMaxLength(20);
        builder.Property(t => t.Ano)
            .HasMaxLength(20);
        builder.Property(t => t.Turma)
            .HasMaxLength(20);
    }
}
