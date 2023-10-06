using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
public class SaudeConfiguration : IEntityTypeConfiguration<Saude>
{
    public void Configure(EntityTypeBuilder<Saude> builder)
    {
        builder.Property(t => t.Envergadura)
            .IsRequired();
    }
}
