using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateAlunoAulas;
public record CreateAlunoAulaCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required string AulaId { get; init; }
}

public class CreateAlunoAulaCommandHandler : IRequestHandler<CreateAlunoAulaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoAulaCommand request, CancellationToken cancellationToken)
    {
        var estrutura = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, estrutura);

        int[] arrAluIds = request.AulaId.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

        foreach (int id in arrAluIds)
        {
            _context.AlunosAulas.Add(new AlunoAula() { AulaId = id, AlunoId = request.AlunoId });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return request.AlunoId;
    }
}
