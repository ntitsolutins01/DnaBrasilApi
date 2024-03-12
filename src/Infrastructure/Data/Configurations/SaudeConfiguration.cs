using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;
public class SaudeConfiguration : IEntityTypeConfiguration<Saude>
{
    public void Configure(EntityTypeBuilder<Saude> builder)
    {
        builder.Property(t => t.StatusSaude)
            .HasMaxLength(1);
    }
}
