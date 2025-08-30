using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.DocumentosAluno.Commands.CreateDocumentoAluno;
public record CreateDocumentoAlunoCommand : IRequest<int>
{
    public int AlunoId { get; init; }
    public required string NomeDocumento { get; init; }
    public required string Url { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateDocumentoAlunoCommandHandler : IRequestHandler<CreateDocumentoAlunoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateDocumentoAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateDocumentoAlunoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        var entity = new DocumentoAluno
        {
            Aluno = aluno,
            NomeDocumento = request.NomeDocumento,
            Url = request.Url
        };

        _context.DocumentosAluno.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
