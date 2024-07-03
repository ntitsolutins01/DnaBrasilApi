using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Cursos.Commands.CreateCurso;
public record CreateCursoCommand : IRequest<int>
{
    public required int TipoCursoId { get; init; }
    public required int UsuarioId { get; init; }
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

        var usuario = await _context.Usuarios
            .FindAsync([request.UsuarioId], cancellationToken);

        Guard.Against.NotFound(request.UsuarioId, usuario);

        var entity = new Curso
        {
            TipoCurso = tipoCurso,
            Usuario = usuario,
            Titulo = request.Titulo,
            CargaHoraria = request.CargaHoraria,
            Descricao = request.Descricao,
        };

        _context.Cursos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
