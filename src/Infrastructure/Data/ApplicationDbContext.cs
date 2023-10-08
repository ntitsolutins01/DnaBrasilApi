using System.Reflection;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;
using DnaBrasil.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasil.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<TipoLaudo> TipoLaudos => Set<TipoLaudo>();
    public DbSet<Serie> Series => Set<Serie>();
    public DbSet<Estado> Estados => Set<Estado>();
    public DbSet<Municipio> Municipios => Set<Municipio>();
    public DbSet<Localidade> Localidades => Set<Localidade>();
    public DbSet<Profissional> Profissionais => Set<Profissional>();
    public DbSet<Deficiencia> Deficiencias => Set<Deficiencia>();
    public DbSet<Ambiente> Ambientes => Set<Ambiente>();
    public DbSet<TalentoEsportivo> TalentoEsportivo => Set<TalentoEsportivo>();
    public DbSet<Saude> Saude => Set<Saude>();
    public DbSet<QualidadeDeVida> QualidadeDeVida => Set<QualidadeDeVida>();
    public DbSet<SaudeBucal> SaudeBucal => Set<SaudeBucal>();
    public DbSet<ConsumoAlimentar> ConsumoAlimentar => Set<ConsumoAlimentar>();
    public DbSet<Vocacional> Vocacional => Set<Vocacional>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
