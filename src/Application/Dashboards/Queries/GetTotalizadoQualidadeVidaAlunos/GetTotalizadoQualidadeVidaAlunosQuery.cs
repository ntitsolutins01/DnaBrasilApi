using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Enums;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadoQualidadeVidaAlunos;
//[Authorize]
public record GetTotalizadoQualidadeVidaAlunosQuery : IRequest<TotalizadorQualidadeVidaDto>
{
    public DashboardDto? SearchFilter { get; init; }
}

public class
    GetTotalizadoQualidadeVidaAlunosQueryHandler : IRequestHandler<GetTotalizadoQualidadeVidaAlunosQuery,
    TotalizadorQualidadeVidaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadoQualidadeVidaAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorQualidadeVidaDto> Handle(GetTotalizadoQualidadeVidaAlunosQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos.Where(x=>x.Id==37051)
            .AsNoTracking();

        var result = FilterAlunosQualidadeVida(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorQualidadeVidaDto FilterAlunosQualidadeVida(IQueryable<Aluno> alunos, DashboardDto search,
        CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            alunos = alunos.Where(u => u.Fomento.Id == id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            alunos = alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            alunos = alunos.Where(u => u.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            alunos = alunos.Where(u => u.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

            alunos = alunos.Where(u => listAlunos.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            alunos = alunos.Where(u => u.Etnia!.Equals(search.Etnia));
        }

        var verificaAlunos = alunos.Select(x => x.Id);

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

        Dictionary<string, decimal> dictTotalizadorQualidadeMasculino = new()
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

        Dictionary<string, decimal> dictTotalizadorQualidadeFeminino = new()
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


        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.QualidadeDeVida).Where(x=>x.QualidadeDeVida != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        foreach (var laudo in laudos)
        {
            var encaminhamentos = laudo.QualidadeDeVida!.Encaminhamentos!.Split(',').Select(item => int.Parse(item)).ToList();

            foreach (int encaminhamento in encaminhamentos)
            {
                var result = _context.Encaminhamentos.Where(x => x.TipoLaudo.Id == (int)EnumTipoLaudo.QualidadeVida).ToList().Find(
                    delegate (Encaminhamento item)
                    {
                        return item.Id == encaminhamento;
                    }
                );

                var value = dict[result!.Parametro];

                value += 1;

                dict[result!.Parametro] = value;

                if (laudo.Aluno.Sexo == "M")
                {
                    var valor = dictTotalizadorQualidadeMasculino[result!.Parametro];

                    valor += 1;

                    dictTotalizadorQualidadeMasculino[result!.Parametro] = valor;
                }
                else
                {
                    var valor = dictTotalizadorQualidadeFeminino[result!.Parametro];

                    valor += 1;

                    dictTotalizadorQualidadeFeminino[result!.Parametro] = valor;
                }
            }
        }

        var totalMasc = dictTotalizadorQualidadeMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorQualidadeVidaMasculino = dictTotalizadorQualidadeMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalMasc).ToString("F")));

        var totalFem = dictTotalizadorQualidadeFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorQualidadeVidaFeminino = dictTotalizadorQualidadeFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalFem).ToString("F")));

        var total = dict.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percQualidadeVida = dict.Where(item => total != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / total).ToString("F")));

        return new TotalizadorQualidadeVidaDto()
        {
            ValorTotalizadorQualidadeVidaMasculino = dictTotalizadorQualidadeMasculino,
            ValorTotalizadorQualidadeVidaFeminino = dictTotalizadorQualidadeFeminino,
            PercTotalizadorQualidadeVidaMasculino = percTotalizadorQualidadeVidaMasculino,
            PercTotalizadorQualidadeVidaFeminino = percTotalizadorQualidadeVidaFeminino,
            PercentualQualidade = percQualidadeVida
        };
    }

}
