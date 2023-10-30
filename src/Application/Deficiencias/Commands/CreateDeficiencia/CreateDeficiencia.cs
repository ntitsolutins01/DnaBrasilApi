using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Deficiencias.Commands.CreateDeficiencia;

public record CreateDeficienciaCommand : IRequest<int>
{
    public required string Nome { get; init; }
    public bool Status { get; init; }
    public List<Aluno>? Alunos { get; init;} 
}

public class CreateDeficienciaCommandHandler : IRequestHandler<CreateDeficienciaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDeficienciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDeficienciaCommand request, CancellationToken cancellationToken)
    {
        var entity = new Deficiencia
        {
            Nome = request.Nome,
            Status = request.Status,
            Alunos = request.Alunos
        };

        _context.Deficiencias.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
