using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.FotosEvento.Commands.CreateFotoEvento;
public record CreateFotoEventoCommand : IRequest<int>
{
    public int EventoId { get; init; }
    public required string NomeArquivo { get; init; }
    public required string Url { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateFotoEventoCommandHandler : IRequestHandler<CreateFotoEventoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFotoEventoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFotoEventoCommand request, CancellationToken cancellationToken)
    {
        var evento = await _context.Eventos
            .FindAsync([request.EventoId], cancellationToken);

        Guard.Against.NotFound(request.EventoId, evento);

        var entity = new FotoEvento
        {
            Evento = evento,
            NomeArquivo = request.NomeArquivo,
            Url = request.Url
        };

        _context.FotosEvento.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
