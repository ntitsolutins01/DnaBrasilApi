using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Disciplinas.Commands.CreateDisciplina;
public record CreateDisciplinaCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateDisciplinaCommandHandler : IRequestHandler<CreateDisciplinaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDisciplinaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDisciplinaCommand request, CancellationToken cancellationToken)
    {
        var entity = new Disciplina
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Status = request.Status
        };

        _context.Disciplinas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
