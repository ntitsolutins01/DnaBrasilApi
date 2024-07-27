using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesAcessosAulas.Commands.DeleteControleAcessoAula;
public record DeleteControleAcessoAulaCommand(int Id) : IRequest<bool>;

public class DeleteControleAcessoAulaCommandHandler : IRequestHandler<DeleteControleAcessoAulaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteControleAcessoAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteControleAcessoAulaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ModulosEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ModulosEad.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
