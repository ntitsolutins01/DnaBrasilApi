using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Aulas.Commands.DeleteAula;
public record DeleteAulaCommand(int Id) : IRequest<bool>;

public class DeleteAulaCommandHandler : IRequestHandler<DeleteAulaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAulaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Aulas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Aulas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
