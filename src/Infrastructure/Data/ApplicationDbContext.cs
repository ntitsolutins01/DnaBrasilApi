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
    public DbSet<Encaminhamento> Encaminhamentos => Set<Encaminhamento>();
    public DbSet<ControleMaterial> ControlesMateriais => Set<ControleMaterial>();
    public DbSet<QuestaoEad> QuestoesEad => Set<QuestaoEad>();
    public DbSet<RespostaEad> RespostasEad => Set<RespostaEad>();
    public DbSet<TextoImagemQuestao> TextosImagensQuestoes => Set<TextoImagemQuestao>();
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
    public DbSet<AlunoCursoCertificado> AlunoCursosCertificados => Set<AlunoCursoCertificado>();
    public DbSet<Inventario> Inventarios => Set<Inventario>();
    public DbSet<ArquivosInventario> ArquivosInventarios => Set<ArquivosInventario>();
    public DbSet<AlunoPresenca> AlunosPresencas => Set<AlunoPresenca>();
    public DbSet<AlunoAula> AlunosAulas => Set<AlunoAula>();
    public DbSet<Educacional> Educacionais => Set<Educacional>();
    public DbSet<DocumentoAluno> DocumentosAluno => Set<DocumentoAluno>();
    public DbSet<ControleFrequenciaEscolar> ControlesFrequenciasEscolares => Set<ControleFrequenciaEscolar>();
    public DbSet<GrauParentesco> GrauParentescos => Set<GrauParentesco>();
    public DbSet<Responsavel> Responsaveis => Set<Responsavel>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

        #region Basic many-to-many

        // ProfissionalModalidade
        builder.Entity<ProfissionalModalidade>().HasKey(sc => new { sc.ProfissionalId, sc.ModalidadeId });

        builder.Entity<ProfissionalModalidade>()
            .HasOne<Profissional>(sc => sc.Profissional)
            .WithMany(s => s.ProfissionalModalidades)
            .HasForeignKey(sc => sc.ProfissionalId);

        builder.Entity<ProfissionalModalidade>()
            .HasOne<Modalidade>(sc => sc.Modalidade)
            .WithMany(s => s.ProfissionalModalidades)
            .HasForeignKey(sc => sc.ModalidadeId);

        // FomentoLocalidade
        builder.Entity<FomentoLocalidade>().HasKey(sc => new { sc.FomentoId, sc.LocalidadeId });

        builder.Entity<FomentoLocalidade>()
            .HasOne<Fomentu>(sc => sc.Fomento)
            .WithMany(s => s.FomentoLocalidades)
            .HasForeignKey(sc => sc.FomentoId);

        builder.Entity<FomentoLocalidade>()
            .HasOne<Localidade>(sc => sc.Localidade)
            .WithMany(s => s.FomentoLocalidades)
            .HasForeignKey(sc => sc.LocalidadeId);

        // FomentoLinhaAcao
        builder.Entity<FomentoLinhaAcao>().HasKey(sc => new { sc.FomentoId, sc.LinhaAcaoId });

        builder.Entity<FomentoLinhaAcao>()
            .HasOne<Fomentu>(sc => sc.Fomento)
            .WithMany(s => s.FomentoLinhasAcoes)
            .HasForeignKey(sc => sc.FomentoId);

        builder.Entity<FomentoLinhaAcao>()
            .HasOne<LinhaAcao>(sc => sc.LinhaAcao)
            .WithMany(s => s.FomentoLinhasAcoes)
            .HasForeignKey(sc => sc.LinhaAcaoId);

        // AlunoModalidade
        builder.Entity<AlunoModalidade>().HasKey(sc => new { sc.AlunoId, sc.ModalidadeId });

        builder.Entity<AlunoModalidade>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AlunoModalidades)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoModalidade>()
            .HasOne<Modalidade>(sc => sc.Modalidade)
            .WithMany(s => s.AlunoModalidades)
            .HasForeignKey(sc => sc.ModalidadeId);

        // AtividadeAluno
        builder.Entity<AtividadeAluno>().HasKey(sc => new { sc.AtividadeId, sc.AlunoId });

        builder.Entity<AtividadeAluno>()
            .HasOne<Atividade>(sc => sc.Atividade)
            .WithMany(s => s.AtividadeAlunos)
            .HasForeignKey(sc => sc.AtividadeId);

        builder.Entity<AtividadeAluno>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AtividadeAlunos)
            .HasForeignKey(sc => sc.AlunoId);

        // AlunoCursoCertificado
        builder.Entity<AlunoCursoCertificado>().HasKey(sc => new { sc.AlunoId, sc.CursoId });

        builder.Entity<AlunoCursoCertificado>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AlunoCursosCertificados)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoCursoCertificado>()
            .HasOne<Curso>(sc => sc.Curso)
            .WithMany(s => s.AlunoCursosCertificados)
            .HasForeignKey(sc => sc.CursoId);

        // AlunoPresenca
        builder.Entity<AlunoPresenca>().HasKey(sc => new { sc.AlunoId, AulaId = sc.AtividadeId });

        builder.Entity<AlunoPresenca>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AlunoPresencas)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoPresenca>()
            .HasOne<Atividade>(sc => sc.Atividade)
            .WithMany(s => s.AlunoPresencas)
            .HasForeignKey(sc => sc.AtividadeId);

        // AlunoAula
        builder.Entity<AlunoAula>().HasKey(sc => new { sc.AlunoId, sc.AulaId });

        builder.Entity<AlunoAula>()
            .HasOne<Aluno>(sc => sc.Aluno)
            .WithMany(s => s.AlunoAulas)
            .HasForeignKey(sc => sc.AlunoId);

        builder.Entity<AlunoAula>()
            .HasOne<Aula>(sc => sc.Aula)
            .WithMany(s => s.AlunoAulas)
            .HasForeignKey(sc => sc.AulaId);

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

        #region multi column index

        builder.Entity<TextoLaudo>()
            .HasIndex(p => new { p.Classificacao, p.Idade, p.Sexo })
            .IsUnique(false);

        #endregion

        #region column index

        builder.Entity<TextoLaudo>()
            .HasIndex(p => p.Aviso)
            .IsUnique(false)
            .IsClustered(false);

        #endregion
    }
}
