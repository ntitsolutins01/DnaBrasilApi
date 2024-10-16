﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class EstadoConfigurations : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.Property(t => t.Sigla)
            .HasMaxLength(2)
            .IsRequired();
        builder.Property(t => t.Nome)
            .HasMaxLength(150)
            .IsRequired();
    }
}
