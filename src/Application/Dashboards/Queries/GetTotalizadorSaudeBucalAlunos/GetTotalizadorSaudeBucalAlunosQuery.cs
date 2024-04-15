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

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private TotalizadorSaudeBucalDto FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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

        //if (!string.IsNullOrWhiteSpace(search.SaudeBucal))
        //{
        //    alunos = alunos.Where(u => u.SaudeBucal!.Equals(search.SaudeBucal));
        //}

        //Dictionary<string, decimal> dict = new()
        //{
        //    { "PARDO", 0 }, { "BRANCO", 0 }, { "PRETO", 0 }, { "INDÍGENA", 0 },{ "AMARELO", 0 }
        //};
        //Dictionary<string, decimal> dictTotalizadorSaudeBucalMasculino = new()
        //{
        //    { "PARDO", 0 }, { "BRANCO", 0 }, { "PRETO", 0 }, { "INDÍGENA", 0 },{ "AMARELO", 0 }
        //};
        //Dictionary<string, decimal> dictTotalizadorSaudeBucalFeminino = new()
        //{
        //    { "PARDO", 0 }, { "BRANCO", 0 }, { "PRETO", 0 }, { "INDÍGENA", 0 },{ "AMARELO", 0 }
        //};

        //foreach (Aluno aluno in alunos.Where(x => x.SaudeBucal != "0"))
        //{
        //    var value = dict[aluno.SaudeBucal!];

        //    value += 1;

        //    dict[aluno.SaudeBucal!] = value;

        //    switch (aluno.SaudeBucal)
        //    {
        //        case "PARDO":
        //            if (aluno.Sexo.Equals("M"))
        //            {
        //                var pardoMasc = dictTotalizadorSaudeBucalMasculino["PARDO"];
        //                pardoMasc += 1;
        //                dictTotalizadorSaudeBucalMasculino["PARDO"] = pardoMasc;
        //            }
        //            else
        //            {
        //                var pardoFem = dictTotalizadorSaudeBucalFeminino["PARDO"];
        //                pardoFem += 1;
        //                dictTotalizadorSaudeBucalFeminino["PARDO"] = pardoFem;
        //            }

        //            break;
        //        case "BRANCO":
        //            if (aluno.Sexo.Equals("M"))
        //            {
        //                var brancoMasc = dictTotalizadorSaudeBucalMasculino["BRANCO"];
        //                brancoMasc += 1;
        //                dictTotalizadorSaudeBucalMasculino["BRANCO"] = brancoMasc;
        //            }
        //            else
        //            {
        //                var brancoFem = dictTotalizadorSaudeBucalFeminino["BRANCO"];
        //                brancoFem += 1;
        //                dictTotalizadorSaudeBucalFeminino["BRANCO"] = brancoFem;
        //            }
        //            break;
        //        case "PRETO":
        //            if (aluno.Sexo.Equals("M"))
        //            {
        //                var pretoMasc = dictTotalizadorSaudeBucalMasculino["PRETO"];
        //                pretoMasc += 1;
        //                dictTotalizadorSaudeBucalMasculino["PRETO"] = pretoMasc;
        //            }
        //            else
        //            {
        //                var pretoFem = dictTotalizadorSaudeBucalFeminino["PRETO"];
        //                pretoFem += 1;
        //                dictTotalizadorSaudeBucalFeminino["PRETO"] = pretoFem;
        //            }
        //            break;
        //        case "INDÍGENA":
        //            if (aluno.Sexo.Equals("M"))
        //            {
        //                var indigenaMasc = dictTotalizadorSaudeBucalMasculino["INDÍGENA"];
        //                indigenaMasc += 1;
        //                dictTotalizadorSaudeBucalMasculino["INDÍGENA"] = indigenaMasc;
        //            }
        //            else
        //            {
        //                var indigenaFem = dictTotalizadorSaudeBucalFeminino["INDÍGENA"];
        //                indigenaFem += 1;
        //                dictTotalizadorSaudeBucalFeminino["INDÍGENA"] = indigenaFem;
        //            }
        //            break;
        //        case "AMARELO":
        //            if (aluno.Sexo.Equals("M"))
        //            {
        //                var amareloMasc = dictTotalizadorSaudeBucalMasculino["AMARELO"];
        //                amareloMasc += 1;
        //                dictTotalizadorSaudeBucalMasculino["AMARELO"] = amareloMasc;
        //            }
        //            else
        //            {
        //                var amareloFem = dictTotalizadorSaudeBucalFeminino["AMARELO"];
        //                amareloFem += 1;
        //                dictTotalizadorSaudeBucalFeminino["AMARELO"] = amareloFem;
        //            }
        //            break;
        //        default:
        //            if (aluno.Sexo.Equals("M"))
        //            {
        //                var amareloMasc = dictTotalizadorSaudeBucalMasculino["AMARELO"];
        //                amareloMasc += 1;
        //                dictTotalizadorSaudeBucalMasculino["AMARELO"] = amareloMasc;
        //            }
        //            else
        //            {
        //                var amareloFem = dictTotalizadorSaudeBucalFeminino["AMARELO"];
        //                amareloFem += 1;
        //                dictTotalizadorSaudeBucalFeminino["AMARELO"] = amareloFem;
        //            }
        //            break;

        //    }
        //}

        //var totalMasc = dictTotalizadorSaudeBucalMasculino.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percTotalizadorSaudeBucalMasculino = dictTotalizadorSaudeBucalMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => 100 * item.Value / totalMasc);

        //var totalFem = dictTotalizadorSaudeBucalFeminino.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percTotalizadorSaudeBucalFeminino = dictTotalizadorSaudeBucalFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => 100 * item.Value / totalFem);

        //var total = dict.Skip(0).Sum(x => x.Value);

        //Dictionary<string, decimal> percSaudeBucal = dict.Where(item => total != 0).ToDictionary(item => item.Key!, item => 100 * item.Value / total);

        //return new TotalizadorSaudeBucalDto
        //{
        //    ValorTotalizadorSaudeBucalMasculino = dictTotalizadorSaudeBucalMasculino,
        //    ValorTotalizadorSaudeBucalFeminino = dictTotalizadorSaudeBucalFeminino,
        //    PercTotalizadorSaudeBucalMasculino = percTotalizadorSaudeBucalMasculino,
        //    PercTotalizadorSaudeBucalFeminino = percTotalizadorSaudeBucalFeminino,
        //    PercSaudeBucal = percSaudeBucal
        //};

        return new TotalizadorSaudeBucalDto();
    }

    /// <summary>
    /// Calcula quantidade de anos passdos com base em duas datas, caso encontre qualquer problema retorna 0 
    /// </summary>
    /// <param name="data">Data inicial</param>
    /// <param name="now">Data final ou deixar nula para data atual</param>
    /// <returns>Retorna inteiro com quantiadde de anos</returns>
    private static int GetIdade(DateTime data, DateTime? now = null)
    {
        // Carrega a data do dia para comparação caso data informada seja nula

        now = ((now == null) ? DateTime.Now : now);

        try
        {
            int YearsOld = (now.Value.Year - data.Year);

            if (now.Value.Month < data.Month || (now.Value.Month == data.Month && now.Value.Day < data.Day))
            {
                YearsOld--;
            }

            return (YearsOld < 0) ? 0 : YearsOld;
        }
        catch
        {
            return 0;
        }
    }
}

