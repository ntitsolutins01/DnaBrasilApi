using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TalentosEsportivos.Commands.UpdateTalentoEsportivo;

public record UpdateTalentoEsportivoCommand : IRequest<bool>
{
    public int Id { get; init; }
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

public class UpdateTalentoEsportivoCommandHandler : IRequestHandler<UpdateTalentoEsportivoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTalentoEsportivoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTalentoEsportivoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TalentosEsportivos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var profissional = await _context.Profissionais.FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        entity.Profissional = profissional;
        entity.Flexibilidade = request.Flexibilidade;
        entity.Altura = request.Altura;
        entity.Peso = request.MassaCorporal;
        entity.Flexibilidade = request.Flexibilidade;
        entity.PreensaoManual = request.PreensaoManual;
        entity.Velocidade = request.Velocidade;
        entity.ImpulsaoHorizontal = request.ImpulsaoHorizontal;
        entity.ShuttleRun = request.Agilidade;
        entity.Vo2Max = request.AptidaoFisica;
        entity.Abdominal = request.Abdominal == true ? 30 : 29;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
