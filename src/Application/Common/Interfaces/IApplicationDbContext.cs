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
    DbSet<Dependencia> Dependencias { get; }
    DbSet<Matricula> Matriculas { get; }
    DbSet<Voucher> Vouchers { get; }
    DbSet<Parceiro> Parceiros { get; }
    DbSet<PlanoAula> PlanosAulas { get; }
    DbSet<Questionario> Questionarios { get; }
    DbSet<Contrato> Contratos { get; }
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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
