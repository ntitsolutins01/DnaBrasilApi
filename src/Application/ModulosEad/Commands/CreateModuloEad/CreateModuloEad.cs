using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ModulosEad.Commands.CreateModuloEad;
public record CreateModuloEadCommand : IRequest<int>
{
    public required int CargaHoraria { get; set; }
    public required int CursoId { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public bool Status { get; init; } = true;
}

public class CreateModuloEadCommandHandler : IRequestHandler<CreateModuloEadCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateModuloEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateModuloEadCommand request, CancellationToken cancellationToken)
    {
        var curso = await _context.Cursos
            .FindAsync([request.CursoId], cancellationToken);

        Guard.Against.NotFound(request.CursoId, curso);

        var entity = new ModuloEad
        {
            CargaHoraria = request.CargaHoraria,
            Curso = curso,
            Titulo = request.Titulo,
            Descricao = request.Descricao,
            Status = request.Status
        };

        _context.ModulosEad.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
