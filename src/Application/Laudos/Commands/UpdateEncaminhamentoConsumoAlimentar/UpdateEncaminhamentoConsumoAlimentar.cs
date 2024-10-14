using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoConsumoAlimentar;

public record UpdateEncaminhamentoConsumoAlimentarCommand : IRequest <bool>
{
    public int? AlunoId { get; init; }

}

public class UpdateEncaminhamentoConsumoAlimentarCommandHandler : IRequestHandler<UpdateEncaminhamentoConsumoAlimentarCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEncaminhamentoConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEncaminhamentoConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var listConsumoAlimentar = _context.ConsumoAlimentares
            .AsNoTracking()
            .OrderByDescending(t => t.Id);

        decimal quadrante1;

        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.ConsumoAlimentar);

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.ConsumoAlimentar).ToList();

        foreach (var consumoAlimentar in listConsumoAlimentar)
        {
            List<int> listRespostas = consumoAlimentar.Respostas.Split(',').Select(item => int.Parse(item)).ToList();

            var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

            quadrante1 = respostas.Where(x => x.Questionario.Quadrante == 1).Sum(s => s.ValorPesoResposta);

            var result = metricas.Find(
                delegate (TextoLaudo item)
                {
                    return quadrante1 >= item.PontoInicial && quadrante1 <= item.PontoFinal && item.Quadrante == 1;
                }
            );

            if (result == null)
            {
                continue;
            }

            var parametro = result.Aviso.Split('.').First();

            var encaminhamentoConsumoAlimentar = encaminhamentos.First(x => x.Parametro == parametro);

            var entity = await _context.ConsumoAlimentares
                .FindAsync([consumoAlimentar.Id], cancellationToken);

            Guard.Against.NotFound(consumoAlimentar.Id, entity);

            entity.Encaminhamento = encaminhamentoConsumoAlimentar;

            await _context.SaveChangesAsync(cancellationToken);
        }

        return true;
    }
}

