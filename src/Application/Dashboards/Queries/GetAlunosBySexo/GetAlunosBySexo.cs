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
        int result = string.IsNullOrWhiteSpace(request.SearchFilter!.Sexo)
            ? await _context.Alunos
                .AsNoTracking()
                .CountAsync(cancellationToken)
            : await _context.Alunos
                .Where(x => x.Sexo == request.SearchFilter!.Sexo)
                .AsNoTracking()
                .CountAsync(cancellationToken);

        return result;
    }

    private int FilterAlunos(IQueryable<Aluno> alunos, DashboardDto search, CancellationToken cancellationToken)
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
            alunos = alunos.Where(u => u.Municipio!.Id.Equals(search.MunicipioId));
        }

        if (!string.IsNullOrWhiteSpace(search.LocalidadeId))
        {
            alunos = alunos.Where(u => u.Localidade!.Id.Equals(search.LocalidadeId));
        }

        return alunos.Count();
    }
}
