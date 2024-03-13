using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetPercentualSaudeAlunos;
//[Authorize]
public record GetPercentualSaudeAlunosQuery : IRequest<List<int>>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetPercentualSaudeAlunosQueryHandler : IRequestHandler<GetPercentualSaudeAlunosQuery, List<int>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPercentualSaudeAlunosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public  Task<List<int>> Handle(GetPercentualSaudeAlunosQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Aluno> alunos;

        alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunosPeriodo(alunos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private List<int> FilterAlunosPeriodo(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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

        var metricasImc = _context.MetricasImc
            .Where(x => x.Sexo!.Equals("G"));

        var verificaAlunos = alunos.Include(i=>i.Saude);

        Dictionary<string, decimal> dict = new();
        int cont = 0;

        foreach (Aluno aluno in verificaAlunos)
        {
            if (aluno.Saude != null)
            {
                double imc = (double)((aluno.Saude!.Massa * 100 * 100) / (aluno.Saude.Massa * aluno.Saude.Altura))!;

                foreach (var item in metricasImc)
                {
                    if (imc >= (double)item.ValorInicial && imc <= (double)item.ValorFinal)
                    {
                        dict.Add(item.Classificacao!, cont++);
                    }
                }
            }
        }

        var list = new List<int> { /*totUltimos3Meses, totUltimos6Meses, totdataEm1Ano*/ };

        return list;
    }
}

