using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequencias.Commands.CreateControleFrequencia;

public record CreateControleFrequenciaCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required int DisciplinaId { get; init; }
    public string? Presenca { get; init; }
    public string? Justificativa { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateControleFrequenciaCommandHandler : IRequestHandler<CreateControleFrequenciaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateControleFrequenciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateControleFrequenciaCommand request, CancellationToken cancellationToken)
    {

        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound<Aluno>(request.AlunoId.ToString(), aluno);

        var disciplina = await _context.Disciplinas
            .FindAsync([request.DisciplinaId], cancellationToken);

        Guard.Against.NotFound<Disciplina>(request.DisciplinaId.ToString(), disciplina);

        var entity = new ControleFrequencia
        {
            Aluno = aluno,
            Disciplina = disciplina,
            Presenca = request.Presenca,
            Justificativa = request.Justificativa,
            Status = request.Status,

        };

        _context.ControlesFrequencias.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
