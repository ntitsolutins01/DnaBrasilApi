using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Series.Commands.DeleteSerie;
public record DeleteSerieCommand(int Id) : IRequest;

public class DeleteSerieCommandHandler : IRequestHandler<DeleteSerieCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteSerieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Series
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Series.Remove(entity);

        //entity.AddDomainEvent(new SerieDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
