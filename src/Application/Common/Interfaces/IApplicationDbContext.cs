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
    DbSet<Localidade> Localidades { get; }
    DbSet<Profissional> Profissionais { get; }
    DbSet<Deficiencia> Deficiencias { get; }
    DbSet<Ambiente> Ambientes { get; }
    DbSet<TalentoEsportivo> TalentoEsportivo { get; }
    DbSet<Saude> Saude { get; }
    DbSet<QualidadeDeVida> QualidadeDeVida { get; }
    DbSet<SaudeBucal> SaudeBucal { get; }
    DbSet<ConsumoAlimentar> ConsumoAlimentar { get; }
    DbSet<Vocacional> Vocacional { get; }
    DbSet<AlunoDados> AlunoDados { get; }
    DbSet<AlunoComplementos> AlunoComplementos { get; }
    DbSet<AlunoMatriculas> AlunoMatriculas { get; }
    DbSet<AlunoAmbientes> AlunoAmbientes { get; }
    DbSet<AlunoDeficiencias> AlunoDeficiencias { get; }
    DbSet<AlunoVouchers> AlunoVouchers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
