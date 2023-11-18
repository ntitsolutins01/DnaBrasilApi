using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Perfis.Commands.DeletePerfil;
public record DeletePerfilCommand(int Id) : IRequest<bool>;

public class DeletePerfilCommandHandler : IRequestHandler<DeletePerfilCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeletePerfilCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePerfilCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Perfis
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Perfis.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 0;
    }

}
