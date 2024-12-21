using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Categorias.Commands.CreateCategoria;
public record CreateCategoriaCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
}

public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoriaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
    {
        var entity = new Categoria
        {
            Nome = request.Nome,
            Descricao = request.Descricao
        };

        _context.Categorias.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
