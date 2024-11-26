using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Certificados.Commands.CreateCertificado;
public record CreateCertificadoCommand : IRequest<int>
{
    public required int CursoId { get; set; }
    public required Byte[] ImgFrente { get; set; }
    public Byte[]? ImgVerso { get; set; }
    public required string HtmlFrente { get; set; }
    public required string HtmlVerso { get; set; }
    public bool Status { get; init; } = true;
}

public class CreateCertificadoCommandHandler : IRequestHandler<CreateCertificadoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCertificadoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCertificadoCommand request, CancellationToken cancellationToken)
    {
        var curso = await _context.Cursos
            .FindAsync([request.CursoId], cancellationToken);

        Guard.Against.NotFound(request.CursoId, curso);

        var entity = new Certificado
        {
            Curso = curso,
            ImgFrente = request.ImgFrente,
            ImgVerso = request.ImgVerso,
            HtmlFrente = request.HtmlFrente,
            HtmlVerso = request.HtmlVerso,
            Status = request.Status
        };

        _context.Certificados.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
