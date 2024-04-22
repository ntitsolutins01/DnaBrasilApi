using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetPercentualSaudeAlunos;
//[Authorize]
public record GetPercentualSaudeAlunosQuery : IRequest<Dictionary<string, decimal>>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetPercentualSaudeAlunosQueryHandler : IRequestHandler<GetPercentualSaudeAlunosQuery, Dictionary<string, decimal>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPercentualSaudeAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<Dictionary<string, decimal>> Handle(GetPercentualSaudeAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private Dictionary<string, decimal> FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            alunos = alunos.Where(u => u.Fomento!.Id == id);
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

        var metricasImc = _context.MetricasImc
            .Where(x => x.Sexo!.Equals("G"));

        var verificaAlunos = alunos.Select(x => x.Id);


        Dictionary<string, decimal> dict = new();
        int cont = 1;

        var laudos = _context.Laudos.Where(x => verificaAlunos.Contains(x.Aluno.Id)).Include(i => i.Saude);

        foreach (var aluno in laudos)
        {
            if (aluno.Saude != null)
            {
                double alturaMetros = (double)(aluno.Saude.Altura * 0.01)!;
                double? imc = (double)aluno.Saude!.Massa! / Math.Pow(alturaMetros, 2);

                foreach (var item in metricasImc)
                {
                    if (!dict.ContainsKey(item.Classificacao!))
                    {
                        dict.Add(item.Classificacao!, 0);
                    }

                    if (imc >= (double)item.ValorInicial && imc <= (double)item.ValorFinal)
                    {
                        if (dict.ContainsKey(item.Classificacao!))
                        {
                            var value = dict[item.Classificacao!];

                            value += 1;

                            dict[item.Classificacao!] = value;
                        }
                        else
                        {
                            dict.Add(item.Classificacao!, cont);
                        }
                    }
                }
            }
        }

        var total = dict.Skip(0).Sum(x => x.Value);

        foreach (KeyValuePair<string, decimal> item in dict)
        {
            dict[item.Key!] = 100 * item.Value / total;
        }

        return dict;
    }
}

