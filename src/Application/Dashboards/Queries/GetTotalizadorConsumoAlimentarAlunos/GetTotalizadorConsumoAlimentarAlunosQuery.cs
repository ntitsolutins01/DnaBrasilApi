using System.Diagnostics.CodeAnalysis;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorConsumoAlimentarAlunos;
//[Authorize]
public record GetTotalizadorConsumoAlimentarAlunosQuery : IRequest<TotalizadorConsumoAlimentarDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class
    GetTotalizadorConsumoAlimentarAlunosQueryHandler : IRequestHandler<GetTotalizadorConsumoAlimentarAlunosQuery,
    TotalizadorConsumoAlimentarDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorConsumoAlimentarAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorConsumoAlimentarDto> Handle(GetTotalizadorConsumoAlimentarAlunosQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos//.Where(x=>x.Id== 38438)//37315 - Feminino
            .AsNoTracking();

        var result = FilterAlunosConsumo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorConsumoAlimentarDto FilterAlunosConsumo(IQueryable<Aluno> alunos, DashboardDto search,
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

        Dictionary<string, decimal> dictConsumoAlimentar = new()
        {
            { "HabitosSaudaveis", 0 },
            { "HabitosNaoSaudaveis", 0 },
            { "HabitosSatisfatorios", 0 },
            { "BonsHabitosAlimentares", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorConsumoAlimentarMasculino = new()
        {
            { "HabitosSaudaveis", 0 },
            { "HabitosNaoSaudaveis", 0 },
            { "HabitosSatisfatorios", 0 },
            { "BonsHabitosAlimentares", 0 }
        };

        Dictionary<string, decimal> dictTotalizadorConsumoAlimentarFeminino = new()
        {
            { "HabitosSaudaveis", 0 },
            { "HabitosNaoSaudaveis", 0 },
            { "HabitosSatisfatorios", 0 },
            { "BonsHabitosAlimentares", 0 }
        };
        
        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.ConsumoAlimentar).Where(x=>x.ConsumoAlimentar != null)
            .Include(a => a.Aluno)
            .AsNoTracking();

        decimal quadrante1;

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == 8).ToList();

        foreach (var aluno in laudos)
        {
            List<int> listRespostas = aluno.ConsumoAlimentar!.Respostas.Split(',').Select(item => int.Parse(item)).ToList();

            var respostas = _context.Respostas.Where(x => listRespostas.Contains(x.Id)).Include(i=>i.Questionario);
            
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

            if (aluno.Aluno.Sexo == "M")
            {
                var valor = dictTotalizadorConsumoAlimentarMasculino[result.Aviso.Split('.')[0]];

                valor += 1;

                dictTotalizadorConsumoAlimentarMasculino[result.Aviso.Split('.')[0]] = valor;
            }
            else
            {
                var valor = dictTotalizadorConsumoAlimentarFeminino[result.Aviso.Split('.')[0]];

                valor += 1;

                dictTotalizadorConsumoAlimentarFeminino[result.Aviso.Split('.')[0]] = valor;
            }
        }

        var totalMasc = dictTotalizadorConsumoAlimentarMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorConsumoAlimentarMasculino = dictTotalizadorConsumoAlimentarMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalMasc).ToString("F")));

        var totalFem = dictTotalizadorConsumoAlimentarFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorConsumoAlimentarFeminino = dictTotalizadorConsumoAlimentarFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalFem).ToString("F")));

        var total = dictConsumoAlimentar.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percConsumoAlimentar = dictConsumoAlimentar.Where(item => total != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / total).ToString("F")));

        return new TotalizadorConsumoAlimentarDto()
        {
            ValorTotalizadorConsumoAlimentarMasculino = dictTotalizadorConsumoAlimentarMasculino,
            ValorTotalizadorConsumoAlimentarFeminino = dictTotalizadorConsumoAlimentarFeminino,
            PercTotalizadorConsumoAlimentarMasculino = percTotalizadorConsumoAlimentarMasculino,
            PercTotalizadorConsumoAlimentarFeminino = percTotalizadorConsumoAlimentarFeminino,
            PercentualConsumoAlimentar = percConsumoAlimentar
        };
    }

}
