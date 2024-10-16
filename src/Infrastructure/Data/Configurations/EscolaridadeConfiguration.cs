﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class EscolaridadeConfiguration : IEntityTypeConfiguration<Escolaridade>
{
    public void Configure(EntityTypeBuilder<Escolaridade> builder)
    {
        builder.Property(t => t.Nome)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(t => t.Status)
            .IsRequired();
        builder.Property(t => t.Descricao)
     .HasMaxLength(100);
    }
}
