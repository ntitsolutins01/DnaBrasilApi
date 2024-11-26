using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Certificados.Commands.UpdateCertificado;

public record UpdateCertificadoCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int CursoId { get; init; }
    public required Byte[] ImgFrente { get; init; }
    public Byte[]? ImgVerso { get; init; }
    public required string HtmlFrente { get; init; }
    public required string HtmlVerso { get; init; }
    public bool Status { get; init; } = true;
}

public class UpdateCertificadoCommandHandler : IRequestHandler<UpdateCertificadoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCertificadoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateCertificadoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Certificados
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var curso = await _context.Cursos
            .FindAsync([request.CursoId], cancellationToken);

        Guard.Against.NotFound(request.CursoId, curso);

        entity.Curso = curso;
        entity.ImgFrente = request.ImgFrente;
        entity.ImgVerso = request.ImgVerso;
        entity.HtmlFrente = request.HtmlFrente;
        entity.HtmlVerso = request.HtmlVerso;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
