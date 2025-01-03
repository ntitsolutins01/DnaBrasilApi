﻿using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class LaudoConfiguration : IEntityTypeConfiguration<Laudo>
{
    public void Configure(EntityTypeBuilder<Laudo> builder)
    {
        builder.Property(t => t.StatusLaudo)
            .HasMaxLength(1);
    }
}
