using DnaBrasilApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DnaBrasilApi.Infrastructure.Data.Configurations;

public class ControleAcessoAulaConfiguration : IEntityTypeConfiguration<ControleAcessoAula>
{
    public void Configure(EntityTypeBuilder<ControleAcessoAula> builder)
    {
        builder.Property(t => t.LiberacaoAula).HasMaxLength(100);
        
    }
}



