using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Certificados.Commands.CreateCertificado;
public record CreateCertificadoCommand : IRequest<int>
{
    public required int FomentoId { get; init; }
    public required string Nome { get; init; }
    public required string Url { get; init; }

    public bool Status { get; init; } = true;
}

public class CreateCertificadoCommandHandler : IRequestHandler<CreateCertificadoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCertificadoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCertificadoCommand request, CancellationToken cancellationToken)
    {
        var fomento = await _context.Fomentos
            .FindAsync([request.FomentoId], cancellationToken);

        Guard.Against.NotFound(request.FomentoId, fomento);

        var entity = new Certificado
        {
            Fomento = fomento,
            Nome = request.Nome,
            Url = request.Url,
            Status = request.Status
        };

        _context.Certificados.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
