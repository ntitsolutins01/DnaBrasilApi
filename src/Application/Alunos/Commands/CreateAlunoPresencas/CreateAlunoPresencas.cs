using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateAlunoPresencas;
public record CreateAlunoPresencaCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required string AulasId { get; init; }
    public required bool Presenca { get; init; }
    public string? Justificativa { get; init; }
    public required string Data { get; init; }
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
                AtividadeId = id,
                AlunoId = request.AlunoId,
                Presenca = request.Presenca,
                Justificativa = request.Justificativa,
                Data = DateTime.ParseExact(request.Data, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"))
            });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return request.AlunoId;
    }
}
