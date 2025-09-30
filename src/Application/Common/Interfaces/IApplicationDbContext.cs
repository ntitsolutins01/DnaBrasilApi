using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<TipoLaudo> TipoLaudos { get; }
    DbSet<Serie> Series { get; }
    DbSet<Estado> Estados { get; }
    DbSet<Municipio> Municipios { get; }
    DbSet<Localidade> Localidades { get; }
    DbSet<Profissional> Profissionais { get; }
    DbSet<Deficiencia> Deficiencias { get; }
    DbSet<Modalidade> Modalidades { get; }
    DbSet<TalentoEsportivo> TalentosEsportivos { get; }
    DbSet<Saude> Saudes { get; }
    DbSet<QualidadeDeVida> QualidadeDeVidas { get; }
    DbSet<SaudeBucal> SaudeBucais { get; }
    DbSet<ConsumoAlimentar> ConsumoAlimentares { get; }
    DbSet<Vocacional> Vocacionais { get; }
    DbSet<Aluno> Alunos { get; }
    DbSet<Parceiro> Parceiros { get; }
    DbSet<PlanoAula> PlanosAulas { get; }
    DbSet<Questionario> Questionarios { get; }
    DbSet<Laudo> Laudos { get; }
    DbSet<Perfil> Perfis { get; }
    DbSet<Usuario> Usuarios { get; }
    DbSet<Modulo> Modulos { get; }
    DbSet<Funcionalidade> Funcionalidades { get; }
    DbSet<Escolaridade> Escolaridades { get; }
    DbSet<Fomentu> Fomentos { get; }
    DbSet<Resposta> Respostas { get; }
    DbSet<TipoParceria> TiposParcerias { get; }
    DbSet<TextoLaudo> TextosLaudos { get; }
    DbSet<ControlePresenca> ControlesPresencas { get; }
    DbSet<MetricaImc> MetricasImc { get; }
    DbSet<LinhaAcao> LinhasAcoes { get; }
    DbSet<TipoCurso> TipoCursos { get; }
    DbSet<Curso> Cursos { get; }
    DbSet<Disciplina> Disciplinas { get; }
    DbSet<Nota> Notas { get; }
    DbSet<ModuloEad> ModulosEad { get; }
    DbSet<Aula> Aulas { get; }
    DbSet<Prova> Provas { get; }
    DbSet<ControleAcessoAula> ControlesAcessosAulas { get; }
    DbSet<Evento> Eventos { get; }
    DbSet<FotoEvento> FotosEvento { get; }
    DbSet<Encaminhamento> Encaminhamentos { get; }
    DbSet<ControleMaterial> ControlesMateriais { get; }
    DbSet<QuestaoEad> QuestoesEad { get; }
    DbSet<RespostaEad> RespostasEad { get; }
    DbSet<TextoImagemQuestao> TextosImagensQuestoes { get; }
    DbSet<Estrutura> Estruturas { get; }
    DbSet<Categoria> Categorias { get; }
    DbSet<Atividade> Atividades { get; }
    DbSet<GrupoMaterial> GruposMateriais { get; }
    DbSet<TipoMaterial> TiposMateriais { get; }
    DbSet<Material> Materiais { get; }
    DbSet<ControleMaterialEstoqueSaida> ControlesMateriaisEstoquesSaidas { get; }
    DbSet<ProfissionalModalidade> ProfissionalModalidades { get; }
    DbSet<FomentoLocalidade> FomentoLocalidades { get; }
    DbSet<FomentoLinhaAcao> FomentoLinhasAcoes { get; }
    DbSet<Certificado> Certificados { get; }
    DbSet<AlunoModalidade> AlunoModalidades { get; }
    DbSet<Ranking> Rankings { get; }
    DbSet<AtividadeAluno> AtividadeAlunos { get; }
    DbSet<EtapaEnsino> EtapasEnsino { get; }
    DbSet<IdebDimensaoNacional> IdebDimensoesNacional { get; }
    DbSet<IdebDimensaoEstadual> IdebDimensoesEstadual { get; }
    DbSet<ModeloCarteirinha> ModelosCarteirinhas { get; }
    DbSet<AlunoCursoCertificado> AlunoCursosCertificados { get; }
    DbSet<Inventario> Inventarios { get; }
    DbSet<ArquivosInventario> ArquivosInventarios { get; }
    DbSet<AlunoPresenca> AlunosPresencas { get; }
    DbSet<AlunoAula> AlunosAulas { get; }
    DbSet<Educacional> Educacionais { get; }
    DbSet<DocumentoAluno> DocumentosAluno { get; }
    DbSet<ControleFrequenciaEscolar> ControlesFrequenciasEscolares { get; }
    DbSet<GrauParentesco> GrauParentescos { get; }
    DbSet<Responsavel> Responsaveis  { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
