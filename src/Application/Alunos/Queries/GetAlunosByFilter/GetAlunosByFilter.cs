using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunosByFilter;

public record GetAlunosByFilterQuery : IRequest<List<AlunoIndexDto>>
{
    public AlunosFilterDto? SearchFilter { get; init; }
}

public class GetAlunosByFilterQueryHandler : IRequestHandler<GetAlunosByFilterQuery, List<AlunoIndexDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoIndexDto>> Handle(GetAlunosByFilterQuery request, CancellationToken cancellationToken)
    {
        var Alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunos(Alunos, request.SearchFilter!, cancellationToken)
            .ProjectTo<AlunoIndexDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken); ;

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Aluno> FilterAlunos(IQueryable<Aluno> Alunos, AlunosFilterDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = _context.Fomentos.Include(i=>i.Municipio).First(x => x.Id == Convert.ToInt32(search.FomentoId));

            Alunos = Alunos.Where(u => u.Municipio!.Id == fomento.Municipio!.Id);
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            Alunos = Alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            Alunos = Alunos.Where(u => u.Municipio!.Id == Convert.ToInt32(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            Alunos = Alunos.Where(u => u.Localidade!.Id == Convert.ToInt32(search.LocalidadeId));
        }

        if (!string.IsNullOrWhiteSpace(search.DeficienciaId))
        {
            var deficiencias = _context.Deficiencias
                .Include(i => i.Alunos)
                .First(f => f.Id == Convert.ToInt32(search.DeficienciaId));

            var listAlunos = deficiencias.Alunos!.Select(s => s.Id).ToList();

            Alunos = Alunos.Where(u => listAlunos.Contains(u.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Etnia))
        {
            Alunos = Alunos.Where(u => u.Etnia!.Equals(search.Etnia));
        }

        return Alunos;
    }
}
