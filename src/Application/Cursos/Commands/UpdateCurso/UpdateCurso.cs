using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Cursos.Commands.UpdateCurso;

public record UpdateCursoCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Titulo { get; init; }
    public required int CargaHoraria { get; init; }
    public string? Descricao { get; init; }
    public string? Imagem { get; init; }
    public string? NomeImagem { get; init; }
    public bool Status { get; init; }
    public required int CoordenadorId { get; init; }
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

        var coordenador = await _context.Usuarios
            .FindAsync([request.CoordenadorId], cancellationToken);

        Guard.Against.NotFound(request.CoordenadorId, coordenador);

        entity.Titulo = request.Titulo;
        entity.CargaHoraria = request.CargaHoraria;
        entity.Descricao = request.Descricao;
        entity.Imagem = request.Imagem;
        entity.NomeImagem = request.NomeImagem;
        entity.Imagem = request.Imagem;
        entity.Status = request.Status;
        entity.Usuario = coordenador;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
