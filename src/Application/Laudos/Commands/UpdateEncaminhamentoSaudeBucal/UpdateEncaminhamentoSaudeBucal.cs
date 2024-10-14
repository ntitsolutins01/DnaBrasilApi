using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoSaudeBucal;

public record UpdateEncaminhamentoSaudeBucalCommand : IRequest<bool>
{
    public int? AlunoId { get; init; }
}

public class UpdateEncaminhamentoSaudeBucalCommandHandler : IRequestHandler<UpdateEncaminhamentoSaudeBucalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEncaminhamentoSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEncaminhamentoSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.SaudeBucal);

        var listSaudeBucal = _context.SaudeBucais
            .AsNoTracking()
            .OrderByDescending(t => t.Id);

        decimal quadrante1;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.SaudeBucal).ToList();

        foreach (var saudeBucal in listSaudeBucal)
        {
            List<int> listRespostas = saudeBucal.Respostas.Split(',').Select(item => int.Parse(item)).ToList();

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

            var encaminhamentoSaudeBucal = encaminhamentos.First(x => x.Parametro == parametro);

            var entity = await _context.SaudeBucais
                .FindAsync([saudeBucal.Id], cancellationToken);

            Guard.Against.NotFound(saudeBucal.Id, entity);

            entity.Encaminhamento = encaminhamentoSaudeBucal;

            await _context.SaveChangesAsync(cancellationToken);
        }

        return true;
    }
}
