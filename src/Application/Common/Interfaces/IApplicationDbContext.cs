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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
