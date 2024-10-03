using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Cursos.Queries.GetCursosAllByTipoCursoId;

public record GetCursosAllByTipoCursoIdQuery : IRequest<List<CursoDto>>
{
    public required int TipoCursoId { get; init; }
}

public class GetCursosAllByTipoCursoIdQueryHandler : IRequestHandler<GetCursosAllByTipoCursoIdQuery, List<CursoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCursosAllByTipoCursoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CursoDto>> Handle(GetCursosAllByTipoCursoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Cursos
            .Include(i=>i.TipoCurso)
            .Include(i=>i.Usuario)
            .Where(x => x.TipoCurso.Id == request.TipoCursoId)
            .AsNoTracking()
            .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
