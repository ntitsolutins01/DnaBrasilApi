using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Cursos.Queries.GetCursosAll;
//[Authorize]
public record GetCursosAllQuery : IRequest<List<CursoDto>>;

public class GetCursosAllQueryHandler : IRequestHandler<GetCursosAllQuery, List<CursoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCursosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CursoDto>> Handle(GetCursosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Cursos
            .AsNoTracking()
            .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
