using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetLaudosPeriodo;
//[Authorize]
public record GetLaudosPeriodoQuery : IRequest<List<int>>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetLaudosPeriodoQueryHandler : IRequestHandler<GetLaudosPeriodoQuery, List<int>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLaudosPeriodoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public  Task<List<int>> Handle(GetLaudosPeriodoQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Laudo> laudos;

        laudos = _context.Laudos
            .Include(i => i.Aluno)
            .AsNoTracking();

        var result = FilterLaudosPeriodo(laudos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private List<int> FilterLaudosPeriodo(IQueryable<Laudo> laudos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = _context.Fomentos.Include(i => i.Municipio).First(x => x.Id == Convert.ToInt32(search.FomentoId));

            laudos = laudos.Where(u => u.Aluno.Municipio!.Id == fomento.Municipio!.Id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            laudos = laudos.Where(u => u.Aluno.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            laudos = laudos.Where(u => u.Aluno.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            laudos = laudos.Where(u => u.Aluno.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

            laudos = laudos.Where(u => listAlunos.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            laudos = laudos.Where(u => u.Aluno.Etnia!.Equals(search.Etnia));
        }

        DateTime dataUltimos3Meses = DateTime.Now.Date.AddDays(-90);
        DateTime dataUltimos6Meses = DateTime.Now.Date.AddDays(-180);
        DateTime dataEm1Ano = DateTime.Now.Date.AddDays(-365);

        var totUltimos3Meses= laudos.Count(x => x.Created > dataUltimos3Meses && x.Created < DateTimeOffset.Now);
        var totUltimos6Meses = laudos.Count(x => x.Created > dataUltimos6Meses && x.Created < DateTimeOffset.Now);
        var totdataEm1Ano = laudos.Count(x => x.Created > dataEm1Ano && x.Created < DateTimeOffset.Now);

        var list = new List<int> { totUltimos3Meses, totUltimos6Meses, totdataEm1Ano };

        return list;
    }
}

