using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data.Configurations;
internal class AlunoAmbientesConfiguration : IEntityTypeConfiguration<AlunoAmbientes>
{
    public void Configure(EntityTypeBuilder<AlunoAmbientes> builder)
    {
        builder.Property(t => t.Ambiente)
            .HasMaxLength(80)
            .IsRequired();
    }
}
