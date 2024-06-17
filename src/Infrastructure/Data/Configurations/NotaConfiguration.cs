using System.ComponentModel.DataAnnotations.Schema;
using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class NotaConfiguration : IEntityTypeConfiguration<Nota>
{
    public void Configure(EntityTypeBuilder<Nota> builder)
    {
        builder.Property(t => t.PrimeiroBimestre).HasPrecision(10, 2);
        builder.Property(t => t.SegundoBimestre).HasPrecision(10, 2);
        builder.Property(t => t.TerceiroBimestre).HasPrecision(10, 2);
        builder.Property(t => t.QuartoBimestre).HasPrecision(10, 2);
        builder.Property(t => t.Media).HasPrecision(10, 2);
        
    }
}



