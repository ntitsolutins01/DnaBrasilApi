using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Modalidades.Commands.CreateModalidade;

public record CreateModalidadeCommand : IRequest<int>
{
    public required string Nome { get; init; }
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
    public bool Status { get; init; } = true;
    public int? LinhaAcaoId { get; init; }
}

public class CreateModalidadeCommandHandler : IRequestHandler<CreateModalidadeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateModalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateModalidadeCommand request, CancellationToken cancellationToken)
    {
        LinhaAcao? linhaAcao = null;

        if (request.LinhaAcaoId != null)
        {
            linhaAcao = await _context.LinhasAcoes.FindAsync([request.LinhaAcaoId], cancellationToken);

            Guard.Against.NotFound((int)request.LinhaAcaoId, linhaAcao);
        }

        var entity = new Modalidade
        {
            Nome = request.Nome,
            Vo2MaxIni = request.Vo2MaxIni,
            Vo2MaxFim = request.Vo2MaxFim,
            VinteMetrosIni = request.VinteMetrosIni,
            VinteMetrosFim = request.VinteMetrosFim,
            ShutlleRunIni = request.ShutlleRunIni,
            ShutlleRunFim = request.ShutlleRunFim,
            FlexibilidadeIni = request.FlexibilidadeIni,
            FlexibilidadeFim = request.FlexibilidadeFim,
            PreensaoManualIni = request.PreensaoManualIni,
            PreensaoManualFim = request.PreensaoManualFim,
            AbdominalPranchaIni = request.AbdominalPranchaIni,
            AbdominalPranchaFim = request.AbdominalPranchaFim,
            ImpulsaoIni = request.ImpulsaoIni,
            ImpulsaoFim = request.ImpulsaoFim,
            EnvergaduraIni = request.EnvergaduraIni,
            EnvergaduraFim = request.EnvergaduraFim,
            PesoIni = request.PesoIni,
            PesoFim = request.PesoFim,
            AlturaIni = request.AlturaIni,
            AlturaFim = request.AlturaFim,
            Status = request.Status,
            LinhaAcao = linhaAcao
        };

        _context.Modalidades.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
