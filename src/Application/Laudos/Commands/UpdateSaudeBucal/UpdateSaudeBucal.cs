using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateSaudeBucal;

public record UpdateSaudeBucalCommand : IRequest <bool>
{
    public required  int Id { get; init; }
    public required int ProfissionalId { get; init; }
    public required string Respostas { get; init; }
    public required string StatusSaudeBucal { get; init; }
}

public class UpdateSaudeBucalCommandHandler : IRequestHandler<UpdateSaudeBucalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.SaudeBucais.FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var profissional = await _context.Profissionais.FindAsync([request.ProfissionalId], cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        entity.Profissional = profissional;
        entity.Respostas = request.Respostas;
        entity.StatusSaudeBucal = request.StatusSaudeBucal;
        entity.Encaminhamento = GetEncaminhamento(request.Respostas);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }

    private Encaminhamento? GetEncaminhamento(string strRespostas)
    {
        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.SaudeBucal);

        decimal quadrante1;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.SaudeBucal).ToList();

        List<int> listRespostas = strRespostas.Split(',').Select(item => int.Parse(item)).ToList();

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
            return null;
        }

        var parametro = result.Aviso.Split('.').First();

        var encaminhamentoSaudeBucal = encaminhamentos.First(x => x.Parametro == parametro);

        return encaminhamentoSaudeBucal;
    }
}
