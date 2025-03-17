using System.Reflection;
using System.Reflection.Emit;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Atividade> Atividades => Set<Atividade>();
    public DbSet<GrupoMaterial> GruposMateriais => Set<GrupoMaterial>();
    public DbSet<TipoMaterial> TiposMateriais => Set<TipoMaterial>();
    public DbSet<Material> Materiais => Set<Material>();
    public DbSet<ControleMaterialEstoqueSaida> ControlesMateriaisEstoquesSaidas => Set<ControleMaterialEstoqueSaida>();
    public DbSet<ProfissionalModalidade> ProfissionalModalidades => Set<ProfissionalModalidade>();
    public DbSet<FomentoLocalidade> FomentoLocalidades => Set<FomentoLocalidade>();
    public DbSet<FomentoLinhaAcao> FomentoLinhasAcoes => Set<FomentoLinhaAcao>();
    public DbSet<Certificado> Certificados => Set<Certificado>();
    public DbSet<AlunoModalidade> AlunoModalidades => Set<AlunoModalidade>();
    public DbSet<Ranking> Rankings => Set<Ranking>();
    public DbSet<AtividadeAluno> AtividadeAlunos => Set<AtividadeAluno>();
    public DbSet<EtapaEnsino> EtapasEnsino => Set<EtapaEnsino>();
    public DbSet<IdebDimensaoNacional> IdebDimensoesNacional => Set<IdebDimensaoNacional>();
    public DbSet<IdebDimensaoEstadual> IdebDimensoesEstadual => Set<IdebDimensaoEstadual>();
    public DbSet<ModeloCarteirinha> ModelosCarteirinhas => Set<ModeloCarteirinha>();
    public DbSet<AlunoCurso> AlunosCursos => Set<AlunoCurso>();
    public DbSet<AlunoCertificado> AlunosCertificados => Set<AlunoCertificado>();
    public DbSet<Inventario> Inventarios => Set<Inventario>();
    public DbSet<ArquivosInventario> ArquivosInventarios => Set<ArquivosInventario>();
    public DbSet<AlunoDisciplina> AlunosDisciplinas => Set<AlunoDisciplina>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

        #region Basic many-to-many

        builder.Entity<ProfissionalModalidade>().HasKey(sc => new { sc.ProfissionalId, sc.ModalidadeId });

        builder.Entity<ProfissionalModalidade>()
            .HasOne<Profissional>(sc => sc.Profissional)
            .WithMany(s => s.ProfissionalModalidades)
            .HasForeignKey(sc => sc.ProfissionalId);

        builder.Entity<ProfissionalModalidade>()
            .HasOne<Modalidade>(sc => sc.Modalidade)
            .WithMany(s => s.ProfissionalModalidades)
            .HasForeignKey(sc => sc.ModalidadeId);

        builder.Entity<FomentoLocalidade>().HasKey(sc => new { sc.FomentoId, sc.LocalidadeId });

        builder.Entity<FomentoLocalidade>()
            .HasOne<Fomentu>(sc => sc.Fomento)
            .WithMany(s => s.FomentoLocalidades)
            .HasForeignKey(sc => sc.FomentoId);

        builder.Entity<FomentoLocalidade>()
            .HasOne<Localidade>(sc => sc.Localidade)
            .WithMany(s => s.FomentoLocalidades)
            .HasForeignKey(sc => sc.LocalidadeId);

        builder.Entity<FomentoLinhaAcao>().HasKey(sc => new { sc.FomentoId, sc.LinhaAcaoId });

        builder.Entity<FomentoLinhaAcao>()
            .HasOne<Fomentu>(sc => sc.Fomento)
            .WithMany(s => s.FomentoLinhasAcoes)
            .HasForeignKey(sc => sc.FomentoId);

        builder.Entity<FomentoLinhaAcao>()
            .HasOne<LinhaAcao>(sc => sc.LinhaAcao)
            .WithMany(s => s.FomentoLinhasAcoes)
            .HasForeignKey(sc => sc.LinhaAcaoId);

        builder.Entity<AlunoModalidade>().HasKey(sc => new { sc.AlunoId, sc.ModalidadeId });

        builder.Entity<AlunoModalidade>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AlunoModalidades)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoModalidade>()
            .HasOne<Modalidade>(sc => sc.Modalidade)
            .WithMany(s => s.AlunoModalidades)
            .HasForeignKey(sc => sc.ModalidadeId);

        builder.Entity<AtividadeAluno>().HasKey(sc => new { sc.AtividadeId, sc.AlunoId });

        builder.Entity<AtividadeAluno>()
            .HasOne<Atividade>(sc => sc.Atividade)
            .WithMany(s => s.AtividadeAlunos)
            .HasForeignKey(sc => sc.AtividadeId);

        builder.Entity<AtividadeAluno>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AtividadeAlunos)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoCurso>().HasKey(sc => new { sc.AlunoId, sc.CursoId });

        builder.Entity<AlunoCurso>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AlunoCursos)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoCurso>()
            .HasOne<Curso>(sc => sc.Curso)
            .WithMany(s => s.AlunoCursos)
            .HasForeignKey(sc => sc.CursoId);

        builder.Entity<AlunoCertificado>().HasKey(sc => new { sc.AlunoId, sc.CertificadoId });

        builder.Entity<AlunoCertificado>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AlunoCertificados)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoCertificado>()
            .HasOne<Certificado>(sc => sc.Certificado)
            .WithMany(s => s.AlunoCertificados)
            .HasForeignKey(sc => sc.CertificadoId);

        builder.Entity<AlunoDisciplina>().HasKey(sc => new { sc.AlunoId, sc.DisciplinaId });

        builder.Entity<AlunoDisciplina>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AlunoDisciplinas)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoDisciplina>()
            .HasOne<Disciplina>(sc => sc.Disciplina)
            .WithMany(s => s.AlunoDisciplinas)
            .HasForeignKey(sc => sc.DisciplinaId);

        #endregion

        #region Required one-to-one with primary key to primary key relationship

        //builder.Entity<Aluno>()
        //    .HasOne(e => e.Dependencia)
        //    .WithOne(e => e.Aluno)
        //    .HasForeignKey<Dependencia>();

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

        #endregion


    }
}
