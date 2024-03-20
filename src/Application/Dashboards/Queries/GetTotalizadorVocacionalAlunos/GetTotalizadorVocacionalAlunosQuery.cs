using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorVocacionalAlunos;
//[Authorize]
public record GetTotalizadorVocacionalAlunosQuery : IRequest<TotalizadorVocacionalDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorVocacionalAlunosQueryHandler : IRequestHandler<GetTotalizadorVocacionalAlunosQuery, TotalizadorVocacionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorVocacionalAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<TotalizadorVocacionalDto> Handle(GetTotalizadorVocacionalAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunos(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorVocacionalDto FilterAlunos(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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


        var verificaAlunos = alunos.Include(i => i.Vocacional);

        Dictionary<string, decimal> dict = new();
        Dictionary<string, decimal> dictTotalizadorVocacionalMasculino = new();
        Dictionary<string, decimal> dictTotalizadorVocacionalFeminino = new();

        //foreach (Modalidade item in modalidades)
        //{
        //    dictTotalizadorVocacionalMasculino.Add(item.Nome!, 0);
        //    dictTotalizadorVocacionalFeminino.Add(item.Nome!, 0);
        //    dict.Add(item.Nome!, 0);
        //}

        //foreach (Aluno aluno in verificaAlunos)
        //{
        //    if (aluno.Vocacional != null)
        //    {
        //        foreach (var item in modalidades)
        //        {
        //            if (aluno.Vocacional.!.Equals(item.Nome))
        //            {
        //                if (aluno.Sexo.Equals("M"))
        //                {
        //                    if (dictTotalizadorVocacionalMasculino.ContainsKey(item.Nome!))
        //                    {
        //                        var value = dictTotalizadorVocacionalMasculino[item.Nome!];

        //                        value += 1;

        //                        dictTotalizadorVocacionalMasculino[item.Nome!] = value;
        //                    }
        //                }
        //                else
        //                {
        //                    if (dictTotalizadorVocacionalFeminino.ContainsKey(item.Nome!))
        //                    {
        //                        var value = dictTotalizadorVocacionalFeminino[item.Nome!];

        //                        value += 1;

        //                        dictTotalizadorVocacionalFeminino[item.Nome!] = value;
        //                    }
        //                }

        //                var valueTotal = dict[item.Nome!];

        //                valueTotal += 1;

        //                dict[item.Nome!] = valueTotal;
        //            }
        //        }
        //    }
        //}

        //var totalMasc = dictTotalizadorVocacionalMasculino.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percTotalizadorVocacionalMasculino = dictTotalizadorVocacionalMasculino.ToDictionary(item => item.Key!, item => 100 * item.Value / totalMasc);

        //var totalFem = dictTotalizadorVocacionalFeminino.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percTotalizadorVocacionalFeminino = dictTotalizadorVocacionalFeminino.ToDictionary(item => item.Key!, item => 100 * item.Value / totalFem);

        //var total = dict.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percVocacional = dict.ToDictionary(item => item.Key!, item => 100 * item.Value / total);

        //return new TotalizadorVocacionalDto
        //{
        //    ValorTotalizadorVocacionalMasculino = dictTotalizadorVocacionalMasculino,
        //    ValorTotalizadorVocacionalFeminino = dictTotalizadorVocacionalFeminino,
        //    PercTotalizadorVocacionalMasculino = percTotalizadorVocacionalMasculino,
        //    PercTotalizadorVocacionalFeminino = percTotalizadorVocacionalFeminino,
        //    PercVocacional = percVocacional
        //};

        return new TotalizadorVocacionalDto();
    }
}

