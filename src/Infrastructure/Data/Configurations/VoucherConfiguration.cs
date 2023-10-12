using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;

internal class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> builder)
    {
        builder.Property(t => t.Descricao)
            .HasMaxLength(100);
        builder.Property(t => t.Turma)
            .HasMaxLength(20);
        builder.Property(t => t.Serie)
            .HasMaxLength(15);
    }
}
