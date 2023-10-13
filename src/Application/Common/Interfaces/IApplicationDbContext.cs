using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<TipoLaudo> TipoLaudos { get; }
    DbSet<Serie> Series { get; }
    DbSet<Estado> Estados { get; }
    DbSet<Municipio> Municipios { get; }
    DbSet<Local> Locais { get; }
    DbSet<Profissional> Profissionais { get; }
    DbSet<Deficiencia> Deficiencias { get; }
    DbSet<Ambiente> Ambientes { get; }
    DbSet<TalentoEsportivo> TalentosEsportivos { get; }
    DbSet<Saude> Saudes { get; }
    DbSet<QualidadeDeVida> QualidadeDeVidas { get; }
    DbSet<SaudeBucal> SaudeBucais { get; }
    DbSet<ConsumoAlimentar> ConsumoAlimentares { get; }
    DbSet<Vocacional> Vocacionais { get; }
    DbSet<Aluno> Alunos { get; }
    DbSet<Dependencia> Dependencias { get; }
    DbSet<Matricula> Matriculas { get; }
    DbSet<Voucher> AlunoVouchers { get; }
    DbSet<SistemaSocioeconomico> SistemaSocioeconomico { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
