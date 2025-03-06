using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.AlunosCursos.Commands.UpdateAlunoCurso;

public record UpdateAlunoCursoCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int Progesso { get; init; }
}

public class UpdateAlunoCursoCommandHandler : IRequestHandler<UpdateAlunoCursoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateAlunoCursoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.AlunosCursos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);
        
        entity.Progresso = request.Progesso;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
