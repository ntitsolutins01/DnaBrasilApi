using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateAlunoPresencas;
public record CreateAlunoPresencaCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required string AulasId { get; init; }
    public required int Presenca { get; init; }
    public string? Justificativa { get; init; }
}

public class CreateAlunoPresencaCommandHandler : IRequestHandler<CreateAlunoPresencaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoPresencaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoPresencaCommand request, CancellationToken cancellationToken)
    {
        var estrutura = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, estrutura);

        int[] arrAluIds = request.AulasId.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

        foreach (int id in arrAluIds)
        {
            _context.AlunosPresencas.Add(new AlunoPresenca()
            {
                AulaId = id, 
                AlunoId = request.AlunoId,
                Presenca = request.Presenca,
                Justificativa = request.Justificativa
            });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return request.AlunoId;
    }
}
