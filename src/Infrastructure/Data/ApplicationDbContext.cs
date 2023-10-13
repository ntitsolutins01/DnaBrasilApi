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
    public DbSet<Local> Locais => Set<Local>();
    public DbSet<Profissional> Profissionais => Set<Profissional>();
    public DbSet<Deficiencia> Deficiencias => Set<Deficiencia>();
    public DbSet<Ambiente> Ambientes => Set<Ambiente>();
    public DbSet<TalentoEsportivo> TalentosEsportivos => Set<TalentoEsportivo>();
    public DbSet<Saude> Saudes => Set<Saude>();
    public DbSet<QualidadeDeVida> QualidadeDeVidas => Set<QualidadeDeVida>();
    public DbSet<SaudeBucal> SaudeBucais => Set<SaudeBucal>();
    public DbSet<ConsumoAlimentar> ConsumoAlimentares => Set<ConsumoAlimentar>();
    public DbSet<Vocacional> Vocacionais => Set<Vocacional>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Dependencia> Dependencias => Set<Dependencia>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Voucher> AlunoVouchers => Set<Voucher>();
    public DbSet<SistemaSocioeconomico> SistemaSocioeconomico => Set<SistemaSocioeconomico>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
            
            builder.Entity<Aluno>()
            .HasMany(e => e.Deficiencias)
            .WithMany(e => e.Alunos)
            .UsingEntity(
                "AlunosDeficiencias",
                r => r.HasOne(typeof(Deficiencia)).WithMany().HasForeignKey("DeficienciaId").HasPrincipalKey(nameof(Deficiencia.Id)),
                l => l.HasOne(typeof(Aluno)).WithMany().HasForeignKey("AlunoId").HasPrincipalKey(nameof(Aluno.Id)),
                j => j.HasKey("AlunoId", "DeficienciaId"));

            builder.Entity<Aluno>()
            .HasMany(e => e.Ambientes)
            .WithMany(e => e.Alunos)
            .UsingEntity(
                "AlunosAmbientes",
                r => r.HasOne(typeof(Ambiente)).WithMany().HasForeignKey("AmbienteId").HasPrincipalKey(nameof(Ambiente.Id)),
                l => l.HasOne(typeof(Aluno)).WithMany().HasForeignKey("AlunoId").HasPrincipalKey(nameof(Aluno.Id)),
                j => j.HasKey("AlunoId", "AmbienteId"));

    }
}
