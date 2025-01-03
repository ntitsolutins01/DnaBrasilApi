using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Categorias.Commands.UpdateCategoria;

public record UpdateCategoriaCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Codigo { get; init; }
    public required string Nome { get; init; }
    public required int IdadeInicial { get; init; }
    public required int IdadeFinal { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
}

public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoriaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categorias
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Codigo = request.Codigo;
        entity.Nome = request.Nome;
        entity.IdadeInicial = request.IdadeInicial;
        entity.IdadeFinal = request.IdadeFinal;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
