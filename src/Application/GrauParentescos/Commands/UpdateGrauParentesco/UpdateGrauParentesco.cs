using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.GrauParentescos.Commands.UpdateGrauParentesco;

public record UpdateGrauParentescoCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; init; }
}

public class UpdateGrauParentescoCommandHandler : IRequestHandler<UpdateGrauParentescoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateGrauParentescoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateGrauParentescoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.GrauParentescos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
