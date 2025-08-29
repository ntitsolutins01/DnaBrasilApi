using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorEducacionalAlunos;
//[Authorize]
public record GetTotalizadorEducacionalAlunosQuery : IRequest<TotalizadorEducacionalDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorEducacionalAlunosQueryHandler : IRequestHandler<GetTotalizadorEducacionalAlunosQuery, TotalizadorEducacionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorEducacionalAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorEducacionalDto> Handle(GetTotalizadorEducacionalAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos//.Where(x=>x.Id== 34101)//37315 - Feminino
            .Where(x => x.Convidado == false)
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorEducacionalDto FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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

        Dictionary<string, decimal> dictEducacional = new()
        {
            { "DEFASAGEM", 0 },
            { "INTERMEDIARIO", 0 },
            { "ADEQUADO", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorEducacionalMasculino = new()
        {
            { "DEFASAGEM", 0 },
            { "INTERMEDIARIO", 0 },
            { "ADEQUADO", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorEducacionalFeminino = new()
        {
            { "DEFASAGEM", 0 },
            { "INTERMEDIARIO", 0 },
            { "ADEQUADO", 0 }
        };

        // TO DO: Arrumar a logica dos totalizador para Matematica e Portugues
        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.EducacionalMatematica).Where(x => x.EducacionalMatematica != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        decimal quadrante1;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == 5).ToList();

        foreach (var aluno in laudos)
        {
            List<int> listRespostas = aluno.EducacionalMatematica!.Respostas.Split(',').Select(item => int.Parse(item)).ToList();

            var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i => i.Questionario);

            quadrante1 = respostas.Where(x => x.Questionario.Quadrante == 1).Sum(s => s.ValorPesoResposta);

            var result = metricas.Find(
                delegate (TextoLaudo item)
                {
                    return quadrante1 >= item.PontoInicial && quadrante1 <= item.PontoFinal && item.Quadrante == 1;
                }
            );

            if (result == null || !dictEducacional.ContainsKey(result.Aviso.Split('.')[0]))
            {
                continue;
            }

            var value = dictEducacional[result.Aviso.Split('.')[0]];

            value += 1;

            dictEducacional[result.Aviso.Split('.')[0]] = value;

            if (aluno.Aluno.Sexo == "M")
            {
                var valor = dictTotalizadorEducacionalMasculino[result.Aviso.Split('.')[0]];

                valor += 1;

                dictTotalizadorEducacionalMasculino[result.Aviso.Split('.')[0]] = valor;
            }
            else
            {
                var valor = dictTotalizadorEducacionalFeminino[result.Aviso.Split('.')[0]];

                valor += 1;

                dictTotalizadorEducacionalFeminino[result.Aviso.Split('.')[0]] = valor;
            }
        }

        var totalMasc = dictTotalizadorEducacionalMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorEducacionalMasculino = dictTotalizadorEducacionalMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalMasc).ToString("F")));

        var totalFem = dictTotalizadorEducacionalFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorEducacionalFeminino = dictTotalizadorEducacionalFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalFem).ToString("F")));

        var total = dictEducacional.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percEducacional = dictEducacional.Where(item => total != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / total).ToString("F")));

        return new TotalizadorEducacionalDto()
        {
            ValorTotalizadorEducacionalMasculino = dictTotalizadorEducacionalMasculino,
            ValorTotalizadorEducacionalFeminino = dictTotalizadorEducacionalFeminino,
            PercTotalizadorEducacionalMasculino = percTotalizadorEducacionalMasculino,
            PercTotalizadorEducacionalFeminino = percTotalizadorEducacionalFeminino,
            PercentualEducacional = percEducacional
        };
    }

}

