using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateAlunoDisciplinas;
public record CreateAlunoDisciplinaCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required string DisciplinasId { get; init; }
}

public class CreateAlunoDisciplinaCommandHandler : IRequestHandler<CreateAlunoDisciplinaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoDisciplinaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoDisciplinaCommand request, CancellationToken cancellationToken)
    {
        var estrutura = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, estrutura);

        int[] arrAluIds = request.DisciplinasId.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

        foreach (int id in arrAluIds)
        {
            _context.AlunosDisciplinas.Add(new AlunoDisciplina() { DisciplinaId = id, AlunoId = request.AlunoId });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return request.AlunoId;
    }
}
