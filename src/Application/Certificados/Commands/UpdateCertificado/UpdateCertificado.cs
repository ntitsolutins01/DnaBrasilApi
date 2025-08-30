using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Certificados.Commands.UpdateCertificado;

public record UpdateCertificadoCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required int FomentoId { get; init; }
    public required string Nome { get; init; }
    public required string Url { get; init; }
    public bool Status { get; init; } = true;
}

public class UpdateCertificadoCommandHandler : IRequestHandler<UpdateCertificadoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCertificadoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCertificadoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Certificados
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var fomento = await _context.Fomentos
            .FindAsync([request.FomentoId], cancellationToken);

        Guard.Against.NotFound(request.FomentoId, fomento);

        entity.Fomento = fomento;
        entity.Nome = request.Nome;
        entity.Url = request.Url;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
