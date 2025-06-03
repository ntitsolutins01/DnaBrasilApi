using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Series.Commands.CreateSerie;
public record CreateSerieCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required string Turma { get; init; }
    public required int EtapaEnsinoId { get; init; }
    public required int LocalidadeId { get; init; }
    public bool Status { get; set; } = true;
}

public class CreateSerieCommandHandler : IRequestHandler<CreateSerieCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSerieCommand request, CancellationToken cancellationToken)
    {
        var etapaEnsino = await _context.EtapasEnsino
            .FindAsync([request.EtapaEnsinoId], cancellationToken);

        Guard.Against.NotFound(request.EtapaEnsinoId, etapaEnsino);

        var localidade = await _context.Localidades
            .FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        var entity = new Serie
        {
            Nome = request.Nome,
            Turma = request.Turma,
            EtapaEnsino = etapaEnsino,
            Localidade = localidade
        };

        _context.Series.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
