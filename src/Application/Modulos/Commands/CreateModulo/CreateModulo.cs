using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Perfis.Commands.CreateModulo;

public record CreateModuloCommand : IRequest<int>
{
    public required string Nome { get; set; }
}

public class CreateModuloCommandHandler : IRequestHandler<CreateModuloCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateModuloCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateModuloCommand request, CancellationToken cancellationToken)
    {
        var entity = new Modulo
        {
            Nome = request.Nome
        };

        _context.Modulos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
