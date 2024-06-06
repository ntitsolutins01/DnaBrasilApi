using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Fomentos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Dashboards.Queries.GetAlunosBySexo;

public record GetAlunosBySexoQuery : IRequest<int>
{
    public DashboardDto? SearchFilter { get; init; }
}

public class GetAlunosBySexoQueryHandler : IRequestHandler<GetAlunosBySexoQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosBySexoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(GetAlunosBySexoQuery request, CancellationToken cancellationToken)
    {
        int result = 0;

        result = string.IsNullOrWhiteSpace(request.SearchFilter!.Sexo)
            ? await _context.Alunos
                .AsNoTracking()
                .CountAsync(cancellationToken)
            : await _context.Alunos
                .Where(x => x.Sexo == request.SearchFilter!.Sexo)
                .AsNoTracking()
                .CountAsync(cancellationToken);

        return result;
    }

    private int FilterAlunos(IQueryable<Aluno> Alunos, DashboardDto search, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(search.FomentoId))
        {
            var fomento = _context.Fomentos.Where(x => x.Id == Convert.ToInt32(search.FomentoId))
                .AsNoTracking()
                .ProjectTo<FomentoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            Alunos = Alunos.Where(u => u.Municipio!.Id.Equals(fomento.Id));
        }

        if (!string.IsNullOrWhiteSpace(search.Estado))
        {
            Alunos = Alunos.Where(u => u.Municipio!.Estado!.Sigla!.Contains(search.Estado));
        }

        if (!string.IsNullOrWhiteSpace(search.MunicipioId))
        {
            Alunos = Alunos.Where(u => u.Municipio!.Id.Equals(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            Alunos = Alunos.Where(u => u.Localidade!.Id.Equals(search.LocalidadeId));
        }

        return Alunos.Count();
    }
}
