using System.Reflection;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Infrastructure.Data;

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
    public DbSet<TalentoEsportivo> TalentosEsportivos => Set<TalentoEsportivo>();
    public DbSet<Saude> Saudes => Set<Saude>();
    public DbSet<QualidadeDeVida> QualidadeDeVidas => Set<QualidadeDeVida>();
    public DbSet<SaudeBucal> SaudeBucais => Set<SaudeBucal>();
    public DbSet<ConsumoAlimentar> ConsumoAlimentares => Set<ConsumoAlimentar>();
    public DbSet<Vocacional> Vocacionais => Set<Vocacional>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Dependencia> Dependencias => Set<Dependencia>();
    public DbSet<MatriculaOld> MatriculasOld => Set<MatriculaOld>();
    public DbSet<Voucher> Vouchers => Set<Voucher>();
    public DbSet<Parceiro> Parceiros => Set<Parceiro>();
    public DbSet<PlanoAula> PlanosAulas => Set<PlanoAula>();
    public DbSet<Questionario> Questionarios => Set<Questionario>();
    public DbSet<Contrato> Contratos => Set<Contrato>();
    public DbSet<Laudo> Laudos => Set<Laudo>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Perfil> Perfis => Set<Perfil>();
    public DbSet<Modulo> Modulos => Set<Modulo>();
    public DbSet<Funcionalidade> Funcionalidades => Set<Funcionalidade>();
    public DbSet<Escolaridade> Escolaridades => Set<Escolaridade>();
    public DbSet<Fomentu> Fomentos => Set<Fomentu>();
    public DbSet<Resposta> Respostas => Set<Resposta>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

        #region Basic many-to-many
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

        builder.Entity<Profissional>()
                    .HasMany(e => e.Ambientes)
                    .WithMany(e => e.Profissionais)
                    .UsingEntity(
                        "ProfissionaisAmbientes",
                        r => r.HasOne(typeof(Ambiente)).WithMany().HasForeignKey("AmbienteId").HasPrincipalKey(nameof(Ambiente.Id)),
                        l => l.HasOne(typeof(Profissional)).WithMany().HasForeignKey("ProfissionalId").HasPrincipalKey(nameof(Profissional.Id)),
                        j => j.HasKey("ProfissionalId", "AmbienteId"));

        builder.Entity<Contrato>()
            .HasMany(e => e.Localidades)
            .WithMany(e => e.Contratos)
            .UsingEntity(
                "ContratosLocalidades",
                r => r.HasOne(typeof(Localidade)).WithMany().HasForeignKey("LocalidadeId").HasPrincipalKey(nameof(Domain.Entities.Localidade.Id)),
                l => l.HasOne(typeof(Contrato)).WithMany().HasForeignKey("ContratoId").HasPrincipalKey(nameof(Contrato.Id)),
                j => j.HasKey("ContratoId", "LocalidadeId"));

        builder.Entity<Contrato>()
            .HasMany(e => e.Alunos)
            .WithMany(e => e.Contratos)
            .UsingEntity(
                "ContratosAlunos",
                r => r.HasOne(typeof(Aluno)).WithMany().HasForeignKey("AlunoId").HasPrincipalKey(nameof(Aluno.Id)),
                l => l.HasOne(typeof(Contrato)).WithMany().HasForeignKey("ContratoId").HasPrincipalKey(nameof(Contrato.Id)),
                j => j.HasKey("ContratoId", "AlunoId"));

        builder.Entity<Contrato>()
            .HasMany(e => e.Profissionais)
            .WithMany(e => e.Contratos)
            .UsingEntity(
                "ContratosProfissionais",
                r => r.HasOne(typeof(Profissional)).WithMany().HasForeignKey("ProfissionalId").HasPrincipalKey(nameof(Profissional.Id)),
                l => l.HasOne(typeof(Contrato)).WithMany().HasForeignKey("ContratoId").HasPrincipalKey(nameof(Contrato.Id)),
                j => j.HasKey("ContratoId", "ProfissionalId"));

        #endregion

        #region Required one-to-one with primary key to primary key relationship

        builder.Entity<Aluno>()
            .HasOne(e => e.Dependencia)
            .WithOne(e => e.Aluno)
            .HasForeignKey<Dependencia>();

        builder.Entity<Aluno>()
            .HasOne(e => e.Matricula)
            .WithOne(e => e.Aluno)
            .HasForeignKey<MatriculaOld>();

        builder.Entity<Aluno>()
            .HasOne(e => e.Voucher)
            .WithOne(e => e.Aluno)
            .HasForeignKey<Voucher>();

        #endregion

        #region Required one-to-many

        builder.Entity<Parceiro>()
            .HasMany(e => e.Alunos)
            .WithOne(e => e.Parceiro)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Modulo>()
            .HasMany(c => c.Funcionalidades)
            .WithOne(e => e.Modulo)
            .IsRequired();

        builder.Entity<Aluno>()
            .HasMany(c => c.Laudos)
            .WithOne(e => e.Aluno)
            .IsRequired();

        #endregion


    }
}
