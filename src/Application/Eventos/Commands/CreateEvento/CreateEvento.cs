using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Eventos.Commands.CreateEvento;
public record CreateEventoCommand : IRequest<int>
{
   public required int LocalidadeId { get; init; }
   public required string Titulo { get; init; }
   public string? Descricao { get; init; }
   public required string DataEvento { get; init; }
   public bool Status { get; init; } = true;
}

public class CreateEventoCommandHandler : IRequestHandler<CreateEventoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEventoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEventoCommand request, CancellationToken cancellationToken)
    {
        var localidade = await _context.Localidades
            .FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        var entity = new Evento
        {
            Localidade = localidade,
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            DataEvento = DateTime.ParseExact(request.DataEvento!, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            Status = request.Status
        };

        _context.Eventos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
