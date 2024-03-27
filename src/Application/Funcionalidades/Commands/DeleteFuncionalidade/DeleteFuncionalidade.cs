using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Funcionalidades.Commands.DeleteFuncionalidade;
public record DeleteFuncionalidadeCommand(int Id) : IRequest<bool>;

public class DeleteFuncionalidadeCommandHandler : IRequestHandler<DeleteFuncionalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteFuncionalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteFuncionalidadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Funcionalidades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Funcionalidades.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
