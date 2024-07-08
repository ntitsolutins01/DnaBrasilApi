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
            .Where(x => x.TipoCurso.Id == request.TipoCursoId)
            .AsNoTracking()
            .ProjectTo<List<CursoDto>>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
