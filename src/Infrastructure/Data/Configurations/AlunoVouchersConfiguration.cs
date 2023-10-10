using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;

internal class AlunoVouchersConfiguration : IEntityTypeConfiguration<AlunoVouchers>
{
    public void Configure(EntityTypeBuilder<AlunoVouchers> builder)
    {
        builder.Property(t => t.Voucher)
            .HasMaxLength(80)
            .IsRequired();
    }
}
