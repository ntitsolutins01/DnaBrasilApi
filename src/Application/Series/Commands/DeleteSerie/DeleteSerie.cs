using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Series.Commands.DeleteSerie;
public record DeleteSerieCommand(int Id) : IRequest<bool>;

public class DeleteSerieCommandHandler : IRequestHandler<DeleteSerieCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteSerieCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteSerieCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Series
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Series.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
