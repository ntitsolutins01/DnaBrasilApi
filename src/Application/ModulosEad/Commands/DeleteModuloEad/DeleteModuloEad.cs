using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.ModulosEad.Commands.DeleteModuloEad;
public record DeleteModuloEadCommand(int Id) : IRequest<bool>;

public class DeleteModuloEadCommandHandler : IRequestHandler<DeleteModuloEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteModuloEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteModuloEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ModulosEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var possuiAulas = _context.Aulas.Any(x => x.ModuloEad != null && x.ModuloEad.Id == request.Id);

        Guard.Against.PossuiAulas(possuiAulas);

        _context.ModulosEad.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
