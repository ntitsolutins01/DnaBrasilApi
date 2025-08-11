using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.CreateControleFrequenciaEscolar;
public record CreateControleFrequenciaEscolarCommand : IRequest<int>
{
    public required string Controle { get; init; }
    public string? AlunoId { get; init; }
    public string? SerieId { get; init; }
    public string? DisciplinaId { get; init; }
    public string? ProfissionalId { get; init; }
    public required string DataFrequencia { get; init; }
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
            .FindAsync([Convert.ToInt32(request.AlunoId)], cancellationToken);

        Guard.Against.NotFound(Convert.ToInt32(request.AlunoId), aluno);

        var serie = await _context.Series
            .FindAsync([Convert.ToInt32(request.SerieId)], cancellationToken);

        Guard.Against.NotFound(Convert.ToInt32(request.SerieId), serie);

        var disciplina = await _context.Disciplinas
            .FindAsync([Convert.ToInt32(request.DisciplinaId)], cancellationToken);

        Guard.Against.NotFound(Convert.ToInt32(request.DisciplinaId), disciplina);

        var profissional = await _context.Profissionais
            .FindAsync([Convert.ToInt32(request.ProfissionalId)], cancellationToken);

        Guard.Against.NotFound(Convert.ToInt32(request.ProfissionalId), profissional);

        var entity = new ControleFrequenciaEscolar
        {
            Controle = request.Controle,
            Aluno = aluno,
            Serie = serie,
            Disciplina = disciplina,
            Profissional = profissional,
            DataFrequencia = DateTime.Parse(request.DataFrequencia, CultureInfo.InvariantCulture)
        };

        _context.ControlesFrequenciasEscolares.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
