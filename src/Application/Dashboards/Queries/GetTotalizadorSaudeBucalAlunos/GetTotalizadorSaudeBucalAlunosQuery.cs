using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorSaudeBucalAlunos;
//[Authorize]
public record GetTotalizadorSaudeBucalAlunosQuery : IRequest<TotalizadorSaudeBucalDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorSaudeBucalAlunosQueryHandler : IRequestHandler<GetTotalizadorSaudeBucalAlunosQuery, TotalizadorSaudeBucalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorSaudeBucalAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorSaudeBucalDto> Handle(GetTotalizadorSaudeBucalAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos//.Where(x=>x.Id== 34101)//37315 - Feminino
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorSaudeBucalDto FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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

        Dictionary<string, decimal> dictSaudeBucal = new()
        {
            { "CUIDADO", 0 },
            { "ATENCAO", 0 },
            { "MUITOBOM", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorSaudeBucalMasculino = new()
        {
            { "CUIDADO", 0 },
            { "ATENCAO", 0 },
            { "MUITOBOM", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorSaudeBucalFeminino = new()
        {
            { "CUIDADO", 0 },
            { "ATENCAO", 0 },
            { "MUITOBOM", 0 }
        };

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.SaudeBucal).Where(x => x.SaudeBucal != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        decimal quadrante1;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == 5).ToList();

        foreach (var aluno in laudos)
        {
            List<int> listRespostas = aluno.SaudeBucal!.Resposta.Split(',').Select(item => int.Parse(item)).ToList();

            var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

            quadrante1 = respostas.Where(x => x.Questionario.Quadrante == 1).Sum(s => s.ValorPesoResposta);

            var result = metricas.Find(
                delegate (TextoLaudo item)
                {
                    return quadrante1 >= item.PontoInicial && quadrante1 <= item.PontoFinal && item.Quadrante == 1;
                }
            );

            if (result == null || !dictSaudeBucal.ContainsKey(result.Aviso.Split('.')[0]))
            {
                continue;
            }

            var value = dictSaudeBucal[result.Aviso.Split('.')[0]];

            value += 1;

            dictSaudeBucal[result.Aviso.Split('.')[0]] = value;

            if (aluno.Aluno.Sexo == "M")
            {
                var valor = dictTotalizadorSaudeBucalMasculino[result.Aviso.Split('.')[0]];

                valor += 1;

                dictTotalizadorSaudeBucalMasculino[result.Aviso.Split('.')[0]] = valor;
            }
            else
            {
                var valor = dictTotalizadorSaudeBucalFeminino[result.Aviso.Split('.')[0]];

                valor += 1;

                dictTotalizadorSaudeBucalFeminino[result.Aviso.Split('.')[0]] = valor;
            }
        }

        var totalMasc = dictTotalizadorSaudeBucalMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorSaudeBucalMasculino = dictTotalizadorSaudeBucalMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalMasc).ToString("F")));

        var totalFem = dictTotalizadorSaudeBucalFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorSaudeBucalFeminino = dictTotalizadorSaudeBucalFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalFem).ToString("F")));

        var total = dictSaudeBucal.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percSaudeBucal = dictSaudeBucal.Where(item => total != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / total).ToString("F")));

        return new TotalizadorSaudeBucalDto()
        {
            ValorTotalizadorSaudeBucalMasculino = dictTotalizadorSaudeBucalMasculino,
            ValorTotalizadorSaudeBucalFeminino = dictTotalizadorSaudeBucalFeminino,
            PercTotalizadorSaudeBucalMasculino = percTotalizadorSaudeBucalMasculino,
            PercTotalizadorSaudeBucalFeminino = percTotalizadorSaudeBucalFeminino,
            PercentualSaudeBucal = percSaudeBucal
        };
    }

}

