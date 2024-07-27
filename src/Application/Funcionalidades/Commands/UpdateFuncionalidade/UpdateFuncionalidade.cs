using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Funcionalidades.Commands.UpdateFuncionalidade;

public record UpdateFuncionalidadeCommand : IRequest<bool>
{
    public int Id { get; init; }
    public int? ModuloId { get; init; }
    public string? Nome { get; init; }
}

public class UpdateFuncionalidadeCommandHandler : IRequestHandler<UpdateFuncionalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateFuncionalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateFuncionalidadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Funcionalidades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
