using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.PlanosAulas.Commands.DeletePlanoAula;
public record DeletePlanoAulaCommand(int Id) : IRequest<bool>;

public class DeletePlanoAulaCommandHandler : IRequestHandler<DeletePlanoAulaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePlanoAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePlanoAulaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.PlanosAulas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.PlanosAulas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
