using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Commands.CreateTalentoEsportivo;

public record CreateTalentoEsportivoCommand : IRequest<int>
{
    public required Profissional Profissional { get; init; }
    public int? Flexibilidade { get; init; }
    public int? PreensaoManual { get; init; }
    public int? Velocidade { get; init; }
    public int? ImpulsaoHorizontal { get; init; }
    public int? AptidaoFisica { get; init; }
    public int? Agilidade { get; init; }
    public int? Abdominal { get; init; }
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
        var entity = new TalentoEsportivo
        {
            Profissional = request.Profissional,
            Flexibilidade = request.Flexibilidade,
            PreensaoManual = request.PreensaoManual,
            Velocidade = request.Velocidade,
            ImpulsaoHorizontal = request.ImpulsaoHorizontal,
            AptidaoFisica = request.AptidaoFisica,
            Agilidade = request.Agilidade,
            Abdominal = request.Abdominal
        };

        _context.TalentosEsportivos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
