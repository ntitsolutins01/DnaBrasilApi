using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Series.Commands.UpdateSerie;

public record UpdateSerieCommand : IRequest <bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public required string Turma { get; init; }
    public required int EtapaEnsinoId { get; init; }
    public required int LocalidadeId { get; init; }
    public bool Status { get; init; }
}

public class UpdateSerieCommandHandler : IRequestHandler<UpdateSerieCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateSerieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Series
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity); 
        
        var etapaEnsino = await _context.EtapasEnsino
            .FindAsync([request.EtapaEnsinoId], cancellationToken);

        Guard.Against.NotFound(request.EtapaEnsinoId, etapaEnsino);

        var localidade = await _context.Localidades
            .FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        entity.Nome = request.Nome;
        entity.Turma = request.Nome;
        entity.EtapaEnsino = etapaEnsino;
        entity.Localidade = localidade;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
