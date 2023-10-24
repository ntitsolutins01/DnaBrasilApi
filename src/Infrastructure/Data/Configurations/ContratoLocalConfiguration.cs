using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class ContratoLocalConfiguration : IEntityTypeConfiguration<ContratoLocal>
{
    public void Configure(EntityTypeBuilder<ContratoLocal> builder)
    {
        builder.Property(t => t.IdContrato)
            .IsRequired();
        builder.Property(t => t.Idlocal)
            .IsRequired();
    }
}
