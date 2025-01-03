using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Commands.DeleteAtividade;
public record DeleteAtividadeCommand(int Id) : IRequest<bool>;

public class DeleteAtividadeCommandHandler : IRequestHandler<DeleteAtividadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteAtividadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAtividadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Atividades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Atividades.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
