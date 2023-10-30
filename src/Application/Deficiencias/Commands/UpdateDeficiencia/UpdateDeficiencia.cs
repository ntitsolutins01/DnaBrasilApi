using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Deficiencias.Commands.UpdateDeficiencia;

public record UpdateDeficienciaCommand : IRequest
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; init; }
    public List<Aluno>? Alunos { get; init; }
}

public class UpdateDeficienciaCommandHandler : IRequestHandler<UpdateDeficienciaCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDeficienciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateDeficienciaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Deficiencias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;
        entity.Alunos = request.Alunos;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
