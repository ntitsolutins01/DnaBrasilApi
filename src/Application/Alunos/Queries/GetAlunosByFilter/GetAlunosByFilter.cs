using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Queries.GetAlunosByFilter;

public record GetAlunosByFilterQuery(SearchAlunosDto search) : IRequest<List<AlunoDto>>;

public class GetAlunosByFilterQueryHandler : IRequestHandler<GetAlunosByFilterQuery, List<AlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoDto>> Handle(GetAlunosByFilterQuery request, CancellationToken cancellationToken)
    {
        var Alunos = _context.Alunos
            .AsNoTracking();

        var result = FilterAlunos(Alunos, request.search)
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken); ;

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Aluno> FilterAlunos(IQueryable<Aluno> Alunos, SearchAlunosDto search)
    {
        if (!string.IsNullOrWhiteSpace(search.Nome))
            Alunos = Alunos.Where(u => u.Nome.Contains(search.Nome));

        return Alunos;
    }
}
