using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Atividades.Commands.CreateAtividade;
public record CreateAtividadeCommand : IRequest<int>
{
    public required int EstruturaId { get; init; }
    public required int LinhaAcaoId { get; init; }
    public required int CategoriaId { get; init; }
    public required int ModalidadeId { get; init; }
    public required string Turma { get; init; }
    public required string HrInicial { get; init; }
    public required string HrFinal { get; init; }
    public required int ProfissionalId { get; init; }
    public required int LocalidadeId { get; init; }
    public required int QuantidadeAluno { get; init; }
    public required string DiasSemana { get; init; }
    public string? ModalidadesIds { get; init; }
}

public class CreateAtividadeCommandHandler : IRequestHandler<CreateAtividadeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAtividadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAtividadeCommand request, CancellationToken cancellationToken)
    {
        var estrutura = await _context.Estruturas
            .FindAsync(new object[] { request.EstruturaId }, cancellationToken);

        Guard.Against.NotFound(request.EstruturaId, estrutura);

        var linhaAcao = await _context.LinhasAcoes
            .FindAsync(new object[] { request.LinhaAcaoId }, cancellationToken);

        Guard.Against.NotFound(request.LinhaAcaoId, linhaAcao);

        var categoria = await _context.Categorias
            .FindAsync(new object[] { request.CategoriaId }, cancellationToken);

        Guard.Against.NotFound(request.CategoriaId, categoria);

        var modalidade = await _context.Modalidades
            .FindAsync(new object[] { request.ModalidadeId }, cancellationToken);

        Guard.Against.NotFound(request.ModalidadeId, modalidade);

        var profissional = await _context.Profissionais
            .FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        var localidade = await _context.Localidades
            .FindAsync(new object[] { request.LocalidadeId }, cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        var entity = new Atividade
        {
            Estrutura = estrutura,
            LinhaAcao = linhaAcao,
            Categoria = categoria,
            Modalidade = modalidade,
            Turma = request.Turma,
            HrInicial = TimeSpan.Parse(request.HrInicial, new CultureInfo("en-US")),
            HrFinal = TimeSpan.Parse(request.HrFinal, new CultureInfo("en-US")),
            Profissional = profissional,
            Localidade = localidade,
            QuantidadeAluno = request.QuantidadeAluno,
            DiasSemana = request.DiasSemana
        };

        _context.Atividades.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
