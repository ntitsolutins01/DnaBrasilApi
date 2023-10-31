﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
public class QualidadeDeVidaConfiguration : IEntityTypeConfiguration<QualidadeDeVida>
{
    public void Configure(EntityTypeBuilder<QualidadeDeVida> builder)
    {
        builder.Property(t => t.Resposta)
            .HasMaxLength(100)
            .IsRequired();
    }
}
