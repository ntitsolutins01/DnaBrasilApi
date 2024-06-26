using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Provas.Commands.DeleteProva;
public record DeleteProvaCommand(int Id) : IRequest<bool>;

public class DeleteProvaCommandHandler : IRequestHandler<DeleteProvaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteProvaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProvaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ModulosEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ModulosEad.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
