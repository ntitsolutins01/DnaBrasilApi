﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
public class LocaisConfiguration : IEntityTypeConfiguration<Local>
{
    public void Configure(EntityTypeBuilder<Local> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Descricao)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.EstadoId)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(t => t.CidadeId)
            .HasMaxLength(150)
            .IsRequired();
    }
}
