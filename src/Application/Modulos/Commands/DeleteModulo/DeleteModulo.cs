using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.Modulos.Commands.DeleteModulo;
public record DeleteModuloCommand(int Id) : IRequest<bool>;

public class DeleteModuloCommandHandler : IRequestHandler<DeleteModuloCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteModuloCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteModuloCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Modulos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var possuiFuncionalidades = _context.Funcionalidades.Any(x => x.Modulo != null && x.Modulo.Id == request.Id);

        Guard.Against.PossuiFuncionalidades(possuiFuncionalidades);

        _context.Modulos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
