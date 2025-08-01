using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.CreateControleFrequenciaEscolar;
public record CreateControleFrequenciaEscolarCommand : IRequest<int>
{
    public required string Controle { get; init; }
    public string? AlunoId { get; init; }
    public string? SerieId { get; init; }
    public string? DisciplinaId { get; init; }
}

public class CreateControleFrequenciaEscolarCommandHandler : IRequestHandler<CreateControleFrequenciaEscolarCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateControleFrequenciaEscolarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateControleFrequenciaEscolarCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId!, aluno);

        var serie = await _context.Series
            .FindAsync([request.SerieId], cancellationToken);

        Guard.Against.NotFound(request.SerieId!, serie);

        var disciplina = await _context.Disciplinas
            .FindAsync([request.DisciplinaId], cancellationToken);

        Guard.Against.NotFound(request.DisciplinaId!, disciplina);

        var entity = new ControleFrequenciaEscolar
        {
            Controle = request.Controle,
            Aluno = aluno,
            Serie = serie,
            Disciplina = disciplina
        };

        _context.ControlesFrequenciasEscolares.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
