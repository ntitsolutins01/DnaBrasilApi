using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateAlunoCertificados;
public record CreateAlunoCertificadoCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required string CertificadosId { get; init; }
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
        var estrutura = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, estrutura);

        int[] arrAluIds = request.CertificadosId.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

        foreach (int id in arrAluIds)
        {
            _context.AlunosCertificados.Add(new AlunoCertificado() { CertificadoId = id, AlunoId = request.AlunoId });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return request.AlunoId;
    }
}
