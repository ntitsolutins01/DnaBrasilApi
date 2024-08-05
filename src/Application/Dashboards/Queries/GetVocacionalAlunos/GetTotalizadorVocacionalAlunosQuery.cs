using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Domain.Entities;
using Boolean = System.Boolean;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetVocacionalAlunos;
//[Authorize]
public record GetTotalizadorVocacionalAlunosQuery : IRequest<VocacionalDto>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetTotalizadorVocacionalAlunosQueryHandler : IRequestHandler<GetTotalizadorVocacionalAlunosQuery, VocacionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTotalizadorVocacionalAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<VocacionalDto> Handle(GetTotalizadorVocacionalAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos//.Where(x=>x.Id==34493)
            .AsNoTracking();

        var result = FilterAlunos(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private VocacionalDto FilterAlunos(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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

        var metricas = _context.TextosLaudos
            .Where(x => x.TipoLaudo.Id == 6).ToList();

        Dictionary<string, decimal> dict = new();
        Dictionary<string, decimal> dictTotalizadorVocacionalMasculino = new();
        Dictionary<string, decimal> dictTotalizadorVocacionalFeminino = new();

        foreach (var metrica in metricas)
        {
            dict.Add(metrica.Aviso.Split('.')[0], 0);
            dictTotalizadorVocacionalMasculino.Add(metrica.Aviso.Split('.')[0], 0);
            dictTotalizadorVocacionalFeminino.Add(metrica.Aviso.Split('.')[0], 0);
        }

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id))
            .Include(a => a.Aluno)
            .Include(i => i.Vocacional!.Encaminhamento)
            .Where(x => x.Vocacional != null)
            .AsNoTracking();


        foreach (var aluno in laudos)
        {
            var result = metricas.Find(
                delegate (TextoLaudo item)

                {
                    return item.Aviso.Split('.')[0] == aluno.Vocacional!.Encaminhamento!.Parametro;
                }
            );

            if (result == null || !dict.ContainsKey(aluno.Vocacional!.Encaminhamento!.Parametro))
            {
                continue;
            }

            var value = dict[aluno.Vocacional!.Encaminhamento!.Parametro];

            value += 1;

            dict[aluno.Vocacional!.Encaminhamento!.Parametro] = value;

            if (aluno.Aluno.Sexo == "M")
            {
                var valor = dictTotalizadorVocacionalMasculino[aluno.Vocacional!.Encaminhamento!.Parametro];

                valor += 1;

                dictTotalizadorVocacionalMasculino[aluno.Vocacional!.Encaminhamento!.Parametro] = valor;
            }
            else
            {
                var valor = dictTotalizadorVocacionalFeminino[aluno.Vocacional!.Encaminhamento!.Parametro];

                valor += 1;

                dictTotalizadorVocacionalFeminino[aluno.Vocacional!.Encaminhamento!.Parametro] = valor;
            }
        }

        var totalMasc = dictTotalizadorVocacionalMasculino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorVocacionalMasculino = dictTotalizadorVocacionalMasculino.Where(item => totalMasc != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalMasc).ToString("F")));

        var totalFem = dictTotalizadorVocacionalFeminino.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percTotalizadorVocacionalFeminino = dictTotalizadorVocacionalFeminino.Where(item => totalFem != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / totalFem).ToString("F")));

        var total = dict.Skip(0).Sum(x => x.Value);

        Dictionary<string, decimal> percVocacional = dict.Where(item => total != 0).ToDictionary(item => item.Key!, item => Convert.ToDecimal((100 * item.Value / total).ToString("F")));

        return new VocacionalDto()
        {
            ValorTotalizadorVocacionalMasculino = dictTotalizadorVocacionalMasculino,
            ValorTotalizadorVocacionalFeminino = dictTotalizadorVocacionalFeminino,
            PercTotalizadorVocacionalMasculino = percTotalizadorVocacionalMasculino,
            PercTotalizadorVocacionalFeminino = percTotalizadorVocacionalFeminino,
            PercentualVocacional = percVocacional
        };
    }
}

