using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.AlunosCursos.Queries.GetAlunosCursosAll;
//[Authorize]
public record GetAlunosCursosAllQuery : IRequest<List<AlunoCursoDto>>;

public class GetAlunosCursosAllQueryHandler : IRequestHandler<GetAlunosCursosAllQuery, List<AlunoCursoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunosCursosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoCursoDto>> Handle(GetAlunosCursosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosCursos
            .AsNoTracking()
            .ProjectTo<AlunoCursoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
