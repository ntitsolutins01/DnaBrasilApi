using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Eventos.Commands.UpdateEvento;

public record UpdateEventoCommand : IRequest <bool>
{
   public required int Id { get; init; }
   public required string Titulo { get; init; }
   public string? Descricao { get; init; }
   public required string DataEvento { get; init; }
   public bool Status { get; init; }
}

public class UpdateEventoCommandHandler : IRequestHandler<UpdateEventoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEventoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateEventoCommand request, CancellationToken cancellationToken)
    {

        var entity = await _context.Eventos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Titulo = request.Titulo;
        entity.Descricao = request.Descricao;
        entity.DataEvento = DateTime.ParseExact(request.DataEvento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
