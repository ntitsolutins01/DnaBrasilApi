﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class ContratoLocalProfissionalConfiguration : IEntityTypeConfiguration<ContratoLocalProfissional>
{
    public void Configure(EntityTypeBuilder<ContratoLocalProfissional> builder)
    {
        builder.Property(t => t.IdContratoLocal)
            .IsRequired();
        builder.Property(t => t.IdProfissional)
            .IsRequired();
    }
}
