using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Modalidades.Commands.DeleteModalidade;
public record DeleteModalidadeCommand(int Id) : IRequest<bool>;

public class DeleteModalidadeCommandHandler : IRequestHandler<DeleteModalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteModalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteModalidadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Modalidades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Modalidades.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
