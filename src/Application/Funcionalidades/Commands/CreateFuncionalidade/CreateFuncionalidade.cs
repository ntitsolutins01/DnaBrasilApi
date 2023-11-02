using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Funcionalidades.Commands.CreateFuncionalidade;

public record CreateFuncionalidadeCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public required int ModuloId { get; init; }
}

public class CreateFuncionalidadeCommandHandler : IRequestHandler<CreateFuncionalidadeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFuncionalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFuncionalidadeCommand request, CancellationToken cancellationToken)
    {
        var modulo = await _context.Modulos
            .FindAsync(new object[] { request.ModuloId }, cancellationToken);

        Guard.Against.NotFound(request.ModuloId, modulo);

        var entity = new Funcionalidade
        {
            Nome = request.Nome,
            Modulo = modulo,
        };

        _context.Funcionalidades.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
