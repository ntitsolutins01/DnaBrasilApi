using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomento.Commands.DeleteFomento;
public record DeleteFomentoCommand(int Id) : IRequest<bool>;

public class DeleteFomentoCommandHandler : IRequestHandler<DeleteFomentoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteFomentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteFomentoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Fomentos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Fomentos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
