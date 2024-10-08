using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateTalentoEsportivo;

public record CreateTalentoEsportivoCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required int ProfissionalId { get; init; }
    public decimal? Altura { get; init; }
    public decimal? MassaCorporal { get; init; }
    public decimal? Flexibilidade { get; init; }
    public decimal? PreensaoManual { get; init; }
    public decimal? Velocidade { get; init; }
    public decimal? ImpulsaoHorizontal { get; init; }
    public decimal? AptidaoFisica { get; init; }
    public decimal? Agilidade { get; init; }
    public bool? Abdominal { get; init; }
    public string? StatusTalentosEsportivos { get; init; }
}

public class CreateTalentoEsportivoCommandHandler : IRequestHandler<CreateTalentoEsportivoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTalentoEsportivoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTalentoEsportivoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos.FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound((int)request.ProfissionalId, profissional);

        var entity = new TalentoEsportivo
        {
            Profissional = profissional,
            Aluno = aluno,
            Altura = request.Altura,
            Peso = request.MassaCorporal,
            Flexibilidade = request.Flexibilidade,
            PreensaoManual = request.PreensaoManual,
            Velocidade = request.Velocidade,
            ImpulsaoHorizontal = request.ImpulsaoHorizontal,
            ShuttleRun = request.Agilidade,
            Vo2Max = request.AptidaoFisica,
            Abdominal = request.Abdominal == true ? 30 : 29
        };

        _context.TalentosEsportivos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
