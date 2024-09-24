using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateConsumoAlimentar;

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
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos//.Where(x => x.Id == 37315)//37315 - Feminino 38438
            .AsNoTracking();

        var verificaAlunos = alunos.Select(x => x.Id);

        Dictionary<string, decimal> dictConsumoAlimentar = new()
        {
            { "HabitosSaudaveis", 0 },
            { "HabitosNaoSaudaveis", 0 },
            { "HabitosSatisfatorios", 0 },
            { "BonsHabitosAlimentares", 0 }
        };
        
        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.ConsumoAlimentar).Where(x => x.ConsumoAlimentar == null)
            .Include(a => a.Aluno)
            .AsNoTracking()
            .OrderBy(o=>o.ConsumoAlimentar!.Id);

        decimal quadrante1;

        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.ConsumoAlimentar);

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == 8).ToList();

        foreach (var laudo in laudos)
        {
            List<int> listRespostas = laudo.ConsumoAlimentar!.Resposta.Split(',').Select(item => int.Parse(item)).ToList();

            var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

            quadrante1 = respostas.Where(x => x.Questionario.Quadrante == 1).Sum(s => s.ValorPesoResposta);

            var result = metricas.Find(
                delegate (TextoLaudo item)
                {
                    return quadrante1 >= item.PontoInicial && quadrante1 <= item.PontoFinal && item.Quadrante == 1;
                }
            );

            if (result == null || !dictConsumoAlimentar.ContainsKey(result.Aviso.Split('.')[0]))
            {
                continue;
            }

            var value = dictConsumoAlimentar[result.Aviso.Split('.')[0]];

            value += 1;

            dictConsumoAlimentar[result.Aviso.Split('.')[0]] = value;

            var parametro = result.Aviso.Split('.').First();

            var encaminhamentoConsumoAlimentar = encaminhamentos.First(x => x.Parametro == parametro);

            var entity = await _context.ConsumoAlimentares
                .FindAsync([laudo.ConsumoAlimentar.Id], cancellationToken);

            Guard.Against.NotFound(laudo.ConsumoAlimentar.Id, entity);

            entity.Encaminhamento = encaminhamentoConsumoAlimentar;

            await _context.SaveChangesAsync(cancellationToken);
        }

        return true;
    }
}

