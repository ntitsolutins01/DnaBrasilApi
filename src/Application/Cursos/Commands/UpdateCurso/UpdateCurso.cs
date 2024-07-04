using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Cursos.Commands.UpdateCurso;

public record UpdateCursoCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Titulo { get; init; }
    public required int CargaHoraria { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
}

public class UpdateCursoCommandHandler : IRequestHandler<UpdateCursoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateCursoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Cursos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Titulo = request.Titulo;
        entity.CargaHoraria = request.CargaHoraria;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
