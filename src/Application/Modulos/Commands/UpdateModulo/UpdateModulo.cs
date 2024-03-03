using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Modulos.Commands.UpdateModulo;

public record UpdateModuloCommand : IRequest <bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
}

public class UpdateModuloCommandHandler : IRequestHandler<UpdateModuloCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateModuloCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateModuloCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Modulos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
