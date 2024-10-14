using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Cursos.Commands.CreateCurso;
public record CreateCursoCommand : IRequest<int>
{
    public required int TipoCursoId { get; init; }
    public required int CoordenadorId { get; init; }
    public required string Titulo { get; init; }
    public required int CargaHoraria { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateCursoCommandHandler : IRequestHandler<CreateCursoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCursoCommand request, CancellationToken cancellationToken)
    {
        var tipoCurso = await _context.TipoCursos
            .FindAsync([request.TipoCursoId], cancellationToken);

        Guard.Against.NotFound(request.TipoCursoId, tipoCurso);

        var coordenador = await _context.Usuarios
            .FindAsync([request.CoordenadorId], cancellationToken);

        Guard.Against.NotFound(request.CoordenadorId, coordenador);

        var entity = new Curso
        {
            TipoCurso = tipoCurso,
            Usuario = coordenador,
            Titulo = request.Titulo,
            CargaHoraria = request.CargaHoraria,
            Descricao = request.Descricao,
        };

        _context.Cursos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
