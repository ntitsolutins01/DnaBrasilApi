using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorTalentoEsportivoAlunos;
//[Authorize]
public record GetTotalizadorTalentoEsportivoAlunosQuery : IRequest<TotalizadorTalentoDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorTalentoEsportivoAlunosQueryHandler : IRequestHandler<GetTotalizadorTalentoEsportivoAlunosQuery, TotalizadorTalentoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorTalentoEsportivoAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorTalentoDto> Handle(GetTotalizadorTalentoEsportivoAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorTalentoDto FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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

        var modalidades = _context.Modalidades
            .Where(x => x.Status == true);

        var verificaAlunos = alunos.Include(i => i.TalentoEsportivo);

        Dictionary<string, decimal> dict = new();
        Dictionary<string, decimal> dictTotalizadorTalentoMasculino = new();
        Dictionary<string, decimal> dictTotalizadorTalentoFeminino = new();

        foreach (Modalidade item in modalidades)
        {
            dictTotalizadorTalentoMasculino.Add(item.Nome!, 0);
            dictTotalizadorTalentoFeminino.Add(item.Nome!, 0);
            dict.Add(item.Nome!, 0);
        }

        foreach (Aluno aluno in verificaAlunos)
        {
            if (aluno.TalentoEsportivo != null)
            {
                foreach (var item in modalidades)
                {
                    if (aluno.TalentoEsportivo.Encaminhamento!.Equals(item.Nome))
                    {
                        if (aluno.Sexo.Equals("M"))
                        {
                            if (dictTotalizadorTalentoMasculino.ContainsKey(item.Nome!))
                            {
                                var value = dictTotalizadorTalentoMasculino[item.Nome!];

                                value += 1;

                                dictTotalizadorTalentoMasculino[item.Nome!] = value;
                            }
                        }
                        else
                        {
                            if (dictTotalizadorTalentoFeminino.ContainsKey(item.Nome!))
                            {
                                var value = dictTotalizadorTalentoFeminino[item.Nome!];

                                value += 1;

                                dictTotalizadorTalentoFeminino[item.Nome!] = value;
                            }
                        }

                        var valueTotal = dict[item.Nome!];

                        valueTotal += 1;

                        dict[item.Nome!] = valueTotal;
                    }
                }
            }
        }

        var totalMasc = dictTotalizadorTalentoMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorTalentoMasculino = dictTotalizadorTalentoMasculino.ToDictionary(item => item.Key!, item => 100 * item.Value / totalMasc);

        var totalFem = dictTotalizadorTalentoFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorTalentoFeminino = dictTotalizadorTalentoFeminino.ToDictionary(item => item.Key!, item => 100 * item.Value / totalFem);

        var total = dict.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTalento = dict.ToDictionary(item => item.Key!, item => 100 * item.Value / total);

        return new TotalizadorTalentoDto
        {
            ValorTotalizadorTalentoMasculino = dictTotalizadorTalentoMasculino,
            ValorTotalizadorTalentoFeminino = dictTotalizadorTalentoFeminino,
            PercTotalizadorTalentoMasculino = percTotalizadorTalentoMasculino,
            PercTotalizadorTalentoFeminino = percTotalizadorTalentoFeminino,
            PercTalento = percTalento
        };
    }
}

