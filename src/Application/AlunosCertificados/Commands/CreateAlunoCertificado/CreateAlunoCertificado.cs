using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.AlunosCertificados.Commands.CreateAlunoCertificado;
public record CreateAlunoCertificadoCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required int CertificadoId { get; init; }
}

public class CreateAlunoCertificadoCommandHandler : IRequestHandler<CreateAlunoCertificadoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoCertificadoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoCertificadoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        var certificado = await _context.Certificados
            .FindAsync([request.CertificadoId], cancellationToken);

        Guard.Against.NotFound(request.CertificadoId, certificado);

        var entity = new AlunoCertificado
        {
            Aluno = aluno,
            Certificado = certificado
        };

        _context.AlunosCertificados.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
