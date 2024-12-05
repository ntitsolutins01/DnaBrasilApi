using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateQualidadeVida;

public record UpdateQualidadeVidaCommand : IRequest <bool>
{
    public required  int Id { get; init; }
    public required int ProfissionalId { get; init; }
    public required string Respostas { get; init; }
    public required string StatusQualidadeDeVida { get; init; }
}

public class UpdateQualidadeVidaCommandHandler : IRequestHandler<UpdateQualidadeVidaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateQualidadeVidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateQualidadeVidaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QualidadeDeVidas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var profissional = await _context.Profissionais.FindAsync([request.ProfissionalId], cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        entity.Profissional = profissional;
        entity.Respostas = request.Respostas;
        entity.StatusQualidadeDeVida = request.StatusQualidadeDeVida;
        entity.Encaminhamentos = GetEncaminhamento(request.Respostas);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }

    private string GetEncaminhamento(string strRespostas)
    {
        var encaminhamento = new List<int>();

        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.QualidadeVida);

        int cont = 0;
        decimal quadrante1;
        decimal quadrante2;
        decimal quadrante3;
        decimal quadrante4;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.QualidadeVida).ToList();

        List<int> listRespostas = strRespostas.Split(',').Select(item => int.Parse(item)).ToList();

        var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

        quadrante1 = respostas.Where(x => x.Questionario.Quadrante == 1).Sum(s => s.ValorPesoResposta);
        quadrante2 = respostas.Where(x => x.Questionario.Quadrante == 2).Sum(s => s.ValorPesoResposta);
        quadrante3 = respostas.Where(x => x.Questionario.Quadrante == 3).Sum(s => s.ValorPesoResposta);
        quadrante4 = respostas.Where(x => x.Questionario.Quadrante == 4).Sum(s => s.ValorPesoResposta);

        Dictionary<int, decimal> dict = new()
        {
            { 1, quadrante1 }, { 2, quadrante2 }, { 3, quadrante3 }, { 4, quadrante4 }
        };

        var list = new List<decimal> { quadrante1, quadrante2, quadrante3, quadrante4 };

        foreach (var quadrante in dict)
        {
            cont++;

            var result = metricas.Find(
                delegate (TextoLaudo item)
                {
                    return quadrante.Value >= item.PontoInicial && quadrante.Value <= item.PontoFinal &&
                           item.Quadrante == quadrante.Key;
                }
            );

            if (result == null)
            {
                continue;
            }

            var parametro = result.Aviso.Split('.').First();

            encaminhamento.Add(encaminhamentos.First(x => x.Parametro == parametro).Id);

        }
        return string.Join(",", encaminhamento);
    }


}
