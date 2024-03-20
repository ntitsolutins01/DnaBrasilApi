using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorDeficienciaAlunos;
//[Authorize]
public record GetTotalizadorDeficienciaAlunosQuery : IRequest<TotalizadorDeficienciaDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorDeficienciaAlunosQueryHandler : IRequestHandler<GetTotalizadorDeficienciaAlunosQuery, TotalizadorDeficienciaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorDeficienciaAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorDeficienciaDto> Handle(GetTotalizadorDeficienciaAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunos(alunos, request.SearchFilter!, cancellationToken);

        return result;
    }

    private Task<TotalizadorDeficienciaDto> FilterAlunos(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = _context.Fomentos.Include(i => i.Municipio).First(x => x.Id == Convert.ToInt32(search.FomentoId));

            alunos = alunos.Where(u => u.Municipio!.Id == fomento.Municipio!.Id);
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

        var defici = _context.Deficiencias.Select(s=>s.Nome).ToList();

        var verificaAlunos = _context.Deficiencias
            .Include(i => i.Alunos)
            .Where(x => x.Alunos!.Any() && x.Status == true).ToList();

        Dictionary<string, decimal> dict = new();
        Dictionary<string, decimal> dictTotalizadorDeficienciaMasculino = new();
        Dictionary<string, decimal> dictTotalizadorDeficienciaFeminino = new();

        foreach (var item in defici)
        {
            dictTotalizadorDeficienciaMasculino.Add(item, 0);
            dictTotalizadorDeficienciaFeminino.Add(item, 0);
            dict.Add(item, 0);

        }

        foreach (var deficiencia in defici)
        {
            foreach (var item in verificaAlunos)
            {
                if (item.Nome.Equals(deficiencia))
                {
                    foreach (var itemAluno in item.Alunos!)
                    {
                        if (itemAluno.Sexo.Equals("M"))
                        {
                            if (dictTotalizadorDeficienciaMasculino.ContainsKey(item.Nome!))
                            {
                                var value = dictTotalizadorDeficienciaMasculino[item.Nome!];

                                value += 1;

                                dictTotalizadorDeficienciaMasculino[item.Nome!] = value;
                            }
                        }
                        else
                        {
                            if (dictTotalizadorDeficienciaFeminino.ContainsKey(item.Nome!))
                            {
                                var value = dictTotalizadorDeficienciaFeminino[item.Nome!];

                                value += 1;

                                dictTotalizadorDeficienciaFeminino[item.Nome!] = value;
                            }
                        }

                        var valueTotal = dict[item.Nome!];

                        valueTotal += 1;

                        dict[item.Nome!] = valueTotal;
                    }

                }
            }
        }

        var totalMasc = dictTotalizadorDeficienciaMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorDeficienciaMasculino = dictTotalizadorDeficienciaMasculino.ToDictionary(item => item.Key!, item => 100 * item.Value / totalMasc);

        var totalFem = dictTotalizadorDeficienciaFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorDeficienciaFeminino = dictTotalizadorDeficienciaFeminino.ToDictionary(item => item.Key!, item => 100 * item.Value / totalFem);

        var total = dict.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percDeficiencia = dict.ToDictionary(item => item.Key!, item => 100 * item.Value / total);

        return Task.FromResult(new TotalizadorDeficienciaDto
        {
            ValorTotalizadorDeficienciaMasculino = dictTotalizadorDeficienciaMasculino,
            ValorTotalizadorDeficienciaFeminino = dictTotalizadorDeficienciaFeminino,
            PercTotalizadorDeficienciaMasculino = percTotalizadorDeficienciaMasculino,
            PercTotalizadorDeficienciaFeminino = percTotalizadorDeficienciaFeminino,
            PercDeficiencia = percDeficiencia
        });
    }
}

