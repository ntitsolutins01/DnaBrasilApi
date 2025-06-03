using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Cursos.Queries.GetCursosByAlunoId;

public record GetCursosByAlunoIdQuery : IRequest<List<CursoDto>>
{
    public required int AlunoId { get; init; }
}

public class GetCursosByAlunoIdQueryHandler : IRequestHandler<GetCursosByAlunoIdQuery, List<CursoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCursosByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CursoDto>> Handle(GetCursosByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunoCursosCertificados
            .Where(ac => ac.AlunoId == request.AlunoId)
            .Include(ac => ac.Curso)
            .AsNoTracking()
            .Select(ac => ac.Curso)
            .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result ?? throw new ArgumentNullException(nameof(result));
    }
}
