using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Commands.UpdateAlunoDeficiencias;

public record UpdateAlunoDeficienciasCommand : IRequest
{
    public int Id { get; init; }
    public List<Deficiencia>? Deficiencias { get; init; }
}

public class UpdateAlunoAmbientesCommandHandler : IRequestHandler<UpdateAlunoDeficienciasCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoAmbientesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateAlunoDeficienciasCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Deficiencias = request.Deficiencias;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
