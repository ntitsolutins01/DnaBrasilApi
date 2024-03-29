using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetControlePresencaByFilter;
//[Authorize]
public record GetControlePresencaByFilterQuery : IRequest<int[]>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetControlePresencaByFilterQueryHandler : IRequestHandler<GetControlePresencaByFilterQuery, int[]>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlePresencaByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<int[]> Handle(GetControlePresencaByFilterQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ControlePresenca> controlePresencas;

        controlePresencas = _context.ControlesPresencas
            .Where(x=>x.Controle==request.SearchFilter!.Controle)
            .Include(i => i.Aluno)
                .AsNoTracking();

        var result = FilterControlePresencas(controlePresencas, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private int[] FilterControlePresencas(IQueryable<ControlePresenca> controlePresencas, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = _context.Fomentos.Include(i => i.Municipio).First(x => x.Id == Convert.ToInt32(search.FomentoId));

            controlePresencas = controlePresencas.Where(u => u.Aluno.Municipio!.Id == fomento.Municipio!.Id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            controlePresencas = controlePresencas.Where(u => u.Aluno.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            controlePresencas = controlePresencas.Where(u => u.Aluno.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            controlePresencas = controlePresencas.Where(u => u.Aluno.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

            controlePresencas = controlePresencas.Where(u => listAlunos.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            controlePresencas = controlePresencas.Where(u => u.Aluno.Etnia!.Equals(search.Etnia));
        }

        var result = controlePresencas.Where(x => x.Created.Year == DateTime.Now.Year)
            .GroupBy(x => new { x.Created.Year, x.Created.Month })
            .Select(grp => new { grp.Key.Year, grp.Key.Month, Count = grp.Count() }).ToList();

        return result.Select(s=>s.Count).ToArray();
    }
}

