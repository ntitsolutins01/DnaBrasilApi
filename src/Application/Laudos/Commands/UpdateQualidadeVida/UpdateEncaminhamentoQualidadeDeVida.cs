using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateQualidadeVida;

public record UpdateEncaminhamentoQualidadeDeVidaCommand : IRequest <bool>
{
    public int? AlunoId { get; init; }
}

public class UpdateEncaminhamentoQualidadeDeVidaCommandHandler : IRequestHandler<UpdateEncaminhamentoQualidadeDeVidaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEncaminhamentoQualidadeDeVidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEncaminhamentoQualidadeDeVidaCommand request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos//.Where(x => x.Id == 37315)//37315 - Feminino 38438
            .AsNoTracking();

        Dictionary<string, decimal> dict = new()
        {
            { "BemEstarFisico", 0 },
            { "MalEstarFisico", 0 },
            { "AutoEstima", 0 },
            { "BaixaAutoEstima", 0 },
            { "FuncionamentoHarmonico", 0 },
            { "Conflitos", 0 },
            { "ContextosFavorecedores", 0 },
            { "ContextosNaoFavorecedores", 0 }
        };

        var encaminhamento = new List<int>();

        var encaminhamentos = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.QualidadeVida);

        var verificaAlunos = alunos.Select(x => x.Id);

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.QualidadeDeVida).Where(x => x.QualidadeDeVida != null)
            .Include(a => a.Aluno)
            .AsNoTracking()
            .OrderBy(t => t.QualidadeDeVida!.Id);

        int cont = 0;
        decimal quadrante1;
        decimal quadrante2;
        decimal quadrante3;
        decimal quadrante4;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.QualidadeVida).ToList();

        foreach (var laudo in laudos)
        {
            List<int> listRespostas = laudo.QualidadeDeVida!.Respostas.Split(',').Select(item => int.Parse(item)).ToList();

            var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

            quadrante1 = respostas.Where(x => x.Questionario.Quadrante == 1).Sum(s => s.ValorPesoResposta);
            quadrante2 = respostas.Where(x => x.Questionario.Quadrante == 2).Sum(s => s.ValorPesoResposta);
            quadrante3 = respostas.Where(x => x.Questionario.Quadrante == 3).Sum(s => s.ValorPesoResposta);
            quadrante4 = respostas.Where(x => x.Questionario.Quadrante == 4).Sum(s => s.ValorPesoResposta);

            var list = new List<decimal> { quadrante1, quadrante2, quadrante3, quadrante4 };

            foreach (decimal quadrante in list)
            {
                cont++;

                var result = metricas.Find(
                    delegate (TextoLaudo item)
                    {
                        return quadrante >= item.PontoInicial && quadrante <= item.PontoFinal && item.Quadrante == cont;
                    }
                );

                if (result == null || !dict.ContainsKey(result.Aviso.Split('.')[0]))
                {
                    continue;
                }

                if (laudo.Aluno.Sexo == "M")
                {
                    var parametro = result.Aviso.Split('.').First();

                    encaminhamento.Add(encaminhamentos.First(x => x.Parametro == parametro).Id);
                }
                else
                {
                    var parametro = result.Aviso.Split('.').First();

                    encaminhamento.Add(encaminhamentos.First(x => x.Parametro == parametro).Id);
                }
            }

            cont = 0;

            var entity = await _context.QualidadeDeVidas
                .FindAsync([laudo.QualidadeDeVida.Id], cancellationToken);

            Guard.Against.NotFound(laudo.QualidadeDeVida.Id, entity);

            entity.Encaminhamentos = string.Join(",", encaminhamento); ;

            await _context.SaveChangesAsync(cancellationToken);

            encaminhamento = new List<int>();
            //return final == 1;
        }

        return false;
    }
}
