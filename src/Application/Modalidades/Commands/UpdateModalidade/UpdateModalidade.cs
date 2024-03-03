using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Modalidades.Commands.UpdateModalidade;

public record UpdateModalidadeCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public int Vo2MaxIni { get; init; }
    public int Vo2MaxFim { get; init; }
    public int VinteMetrosIni { get; init; }
    public int VinteMetrosFim { get; init; }
    public int ShutlleRunIni { get; init; }
    public int ShutlleRunFim { get; init; }
    public int FlexibilidadeIni { get; init; }
    public int FlexibilidadeFim { get; init; }
    public int PreensaoManualIni { get; init; }
    public int PreensaoManualFim { get; init; }
    public int AbdominalPranchaIni { get; init; }
    public int AbdominalPranchaFim { get; init; }
    public int ImpulsaoIni { get; init; }
    public int ImpulsaoFim { get; init; }
    public int EnvergaduraIni { get; init; }
    public int EnvergaduraFim { get; init; }
    public int PesoIni { get; init; }
    public int PesoFim { get; init; }
    public int AlturaIni { get; init; }
    public int AlturaFim { get; init; }
    public bool Status { get; init; }
}

public class UpdateModalidadeCommandHandler : IRequestHandler<UpdateModalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateModalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateModalidadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Modalidades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Vo2MaxIni = request.Vo2MaxIni;
        entity.Vo2MaxFim = request.Vo2MaxFim;
        entity.VinteMetrosIni = request.VinteMetrosIni;
        entity.VinteMetrosFim = request.VinteMetrosFim;
        entity.ShutlleRunIni = request.ShutlleRunIni;
        entity.ShutlleRunFim = request.ShutlleRunFim;
        entity.FlexibilidadeIni = request.FlexibilidadeIni;
        entity.FlexibilidadeFim = request.FlexibilidadeFim;
        entity.PreensaoManualIni = request.PreensaoManualIni;
        entity.PreensaoManualFim = request.PreensaoManualFim;
        entity.AbdominalPranchaIni = request.AbdominalPranchaIni;
        entity.AbdominalPranchaFim = request.AbdominalPranchaFim;
        entity.ImpulsaoIni = request.ImpulsaoIni;
        entity.ImpulsaoFim = request.ImpulsaoFim;
        entity.EnvergaduraIni = request.EnvergaduraIni;
        entity.EnvergaduraFim = request.EnvergaduraFim;
        entity.PesoIni = request.PesoIni;
        entity.PesoFim = request.PesoFim;
        entity.AlturaIni = request.AlturaIni;
        entity.AlturaFim = request.AlturaFim;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
