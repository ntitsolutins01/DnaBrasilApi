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
    public DbSet<Modalidade> Modalidades => Set<Modalidade>();
    public DbSet<TalentoEsportivo> TalentosEsportivos => Set<TalentoEsportivo>();
    public DbSet<Saude> Saudes => Set<Saude>();
    public DbSet<QualidadeDeVida> QualidadeDeVidas => Set<QualidadeDeVida>();
    public DbSet<SaudeBucal> SaudeBucais => Set<SaudeBucal>();
    public DbSet<ConsumoAlimentar> ConsumoAlimentares => Set<ConsumoAlimentar>();
    public DbSet<Vocacional> Vocacionais => Set<Vocacional>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Voucher> Vouchers => Set<Voucher>();
    public DbSet<Parceiro> Parceiros => Set<Parceiro>();
    public DbSet<PlanoAula> PlanosAulas => Set<PlanoAula>();
    public DbSet<Questionario> Questionarios => Set<Questionario>();
    public DbSet<Laudo> Laudos => Set<Laudo>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Perfil> Perfis => Set<Perfil>();
    public DbSet<Modulo> Modulos => Set<Modulo>();
    public DbSet<Funcionalidade> Funcionalidades => Set<Funcionalidade>();
    public DbSet<Escolaridade> Escolaridades => Set<Escolaridade>();
    public DbSet<Fomentu> Fomentos => Set<Fomentu>();
    public DbSet<Resposta> Respostas => Set<Resposta>();
    public DbSet<TipoParceria> TiposParcerias => Set<TipoParceria>();
    public DbSet<TextoLaudo> TextosLaudos => Set<TextoLaudo>();
    public DbSet<ControlePresenca> ControlesPresencas => Set<ControlePresenca>();
    public DbSet<MetricaImc> MetricasImc => Set<MetricaImc>();
    public DbSet<LinhaAcao> LinhasAcoes => Set<LinhaAcao>();
    public DbSet<TipoCurso> TipoCursos => Set<TipoCurso>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Disciplina> Disciplinas => Set<Disciplina>();
    public DbSet<Nota> Notas => Set<Nota>();
    public DbSet<ModuloEad> ModulosEad => Set<ModuloEad>();
    public DbSet<Aula> Aulas => Set<Aula>();
    public DbSet<Prova> Provas => Set<Prova>();
    public DbSet<ControleAcessoAula> ControlesAcessosAulas => Set<ControleAcessoAula>();
    public DbSet<Evento> Eventos => Set<Evento>();
    public DbSet<FotoEvento> FotosEvento => Set<FotoEvento>();
    public DbSet<Encaminhamento> Encaminhamentos=> Set<Encaminhamento>();
    public DbSet<ControleMaterial> ControlesMateriais => Set<ControleMaterial>();
    public DbSet<QuestaoEad> QuestoesEad => Set<QuestaoEad>();
    public DbSet<RespostaEad> RespostasEad => Set<RespostaEad>();
    public DbSet<TextoQuestao> TextosQuestoes => Set<TextoQuestao>();
    public DbSet<Estrutura> Estruturas => Set<Estrutura>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

        #region Basic many-to-many
        builder.Entity<Fomentu>()
        .HasMany(e => e.LinhasAcoes)
        .WithMany(e => e.Fomentos)
        .UsingEntity(
            "FomentosLinhasAcoes",
            r => r.HasOne(typeof(LinhaAcao)).WithMany().HasForeignKey("LinhaAcaoId").HasPrincipalKey(nameof(LinhaAcao.Id)),
            l => l.HasOne(typeof(Fomentu)).WithMany().HasForeignKey("FomentoId").HasPrincipalKey(nameof(Fomentu.Id)),
            j => j.HasKey("FomentoId", "LinhaAcaoId"));

        builder.Entity<Aluno>()
        .HasMany(e => e.Modalidades)
        .WithMany(e => e.Alunos)
        .UsingEntity(
            "AlunosModalidades",
            r => r.HasOne(typeof(Modalidade)).WithMany().HasForeignKey("ModalidadeId").HasPrincipalKey(nameof(Modalidade.Id)),
            l => l.HasOne(typeof(Aluno)).WithMany().HasForeignKey("AlunoId").HasPrincipalKey(nameof(Aluno.Id)),
            j => j.HasKey("AlunoId", "ModalidadeId"));

        builder.Entity<Profissional>()
                    .HasMany(e => e.Modalidades)
                    .WithMany(e => e.Profissionais)
                    .UsingEntity(
                        "ProfissionaisModalidades",
                        r => r.HasOne(typeof(Modalidade)).WithMany().HasForeignKey("ModalidadeId").HasPrincipalKey(nameof(Modalidade.Id)),
                        l => l.HasOne(typeof(Profissional)).WithMany().HasForeignKey("ProfissionalId").HasPrincipalKey(nameof(Profissional.Id)),
                        j => j.HasKey("ProfissionalId", "ModalidadeId"));

        

        #endregion

        #region Required one-to-one with primary key to primary key relationship

        //builder.Entity<Aluno>()
        //    .HasOne(e => e.Dependencia)
        //    .WithOne(e => e.Aluno)
        //    .HasForeignKey<Dependencia>();

        builder.Entity<Aluno>()
            .HasOne(e => e.Matricula)
            .WithOne(e => e.Aluno)
            .HasForeignKey<Matricula>();

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
            .HasMany(c => c.QualidadeDeVidas)
            .WithOne(e => e.Aluno)
            .IsRequired();

        #endregion


    }
}
