using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.GrauParentescos.Commands.DeleteGrauParentesco;
public record DeleteGrauParentescoCommand(int Id) : IRequest<bool>;

public class DeleteGrauParentescoCommandHandler : IRequestHandler<DeleteGrauParentescoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteGrauParentescoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteGrauParentescoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.GrauParentescos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.GrauParentescos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
