using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.GrauParentescos.Commands.CreateGrauParentesco;
public record CreateGrauParentescoCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateGrauParentescoCommandHandler : IRequestHandler<CreateGrauParentescoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateGrauParentescoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateGrauParentescoCommand request, CancellationToken cancellationToken)
    {
        var entity = new GrauParentesco
        {
            Nome = request.Nome,
            Status = request.Status
        };

        _context.GrauParentescos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
