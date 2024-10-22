using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TalentosEsportivos.Commands.UpdateTalentoEsportivo;

public record UpdateTalentoEsportivoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public int? Flexibilidade { get; init; }
    public int? PreensaoManual { get; init; }
    public int? Velocidade { get; init; }
    public int? ImpulsaoHorizontal { get; init; }
    public int? AptidaoFisica { get; init; }
    public int? Agilidade { get; init; }
    public int? Abdominal { get; init; }
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

        entity.Flexibilidade = request.Flexibilidade;
        entity.PreensaoManual = request.PreensaoManual;
        entity.Velocidade = request.Velocidade;
        entity.ImpulsaoHorizontal = request.ImpulsaoHorizontal;
        entity.Vo2Max = request.AptidaoFisica;
        entity.Abdominal = request.Abdominal;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
