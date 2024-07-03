using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TipoCursos.Commands.CreateTipoCurso;
public record CreateTipoCursoCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateTipoCursoCommandHandler : IRequestHandler<CreateTipoCursoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTipoCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTipoCursoCommand request, CancellationToken cancellationToken)
    {
        var entity = new TipoCurso
        {
            Nome = request.Nome,
        };

        _context.TipoCursos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
