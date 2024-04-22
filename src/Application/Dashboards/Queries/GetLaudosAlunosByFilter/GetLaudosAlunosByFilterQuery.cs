using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetLaudosAlunosByFilter;
//[Authorize]
public record GetLaudosAlunosByFilterQuery : IRequest<int>
{
    public DashboardDto? SearchFilter { get; init; }

}

public class GetLaudosAlunosByFilterQueryHandler : IRequestHandler<GetLaudosAlunosByFilterQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLaudosAlunosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<int> Handle(GetLaudosAlunosByFilterQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Laudo> Laudos;

        Laudos = string.IsNullOrWhiteSpace(request.SearchFilter!.StatusLaudo)
            ? _context.Laudos
                .Include(i=>i.Aluno)
                .AsNoTracking()
            : _context.Laudos
                .Include(i => i.Aluno)
                .Where(x => x.StatusLaudo == request.SearchFilter!.StatusLaudo)
                .AsNoTracking();

        var result = FilterLaudos(Laudos, request.SearchFilter!, cancellationToken);

        return Task.FromResult(result);
    }

    private int FilterLaudos(IQueryable<Laudo> laudos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var id = Convert.ToInt32(search.FomentoId.Split("-")[0]);

            laudos = laudos.Where(u => u.Aluno.Fomento!.Id == id);
        }

        if (!string.IsNullOrWhiteSpace(search.Sexo))
        {
            laudos = laudos.Where(u => u.Aluno.Sexo.Contains(search.Sexo));
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

        return laudos.Count();
    }
}

