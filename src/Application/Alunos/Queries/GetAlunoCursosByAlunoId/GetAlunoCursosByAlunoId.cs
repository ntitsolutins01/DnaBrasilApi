using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunoCursosByAlunoId;
//[Authorize]
public record GetAlunoCursosByAlunoIdQuery : IRequest<List<AlunoCursoDto>>
{
    public required int AlunoId { get; init; }
}

public class GetAlunoCursosByAlunoIdQueryHandler : IRequestHandler<GetAlunoCursosByAlunoIdQuery, List<AlunoCursoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunoCursosByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoCursoDto>> Handle(GetAlunoCursosByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunoCursosCertificados
            .Where((x => x.AlunoId == request.AlunoId))
            .AsNoTracking()
            .ProjectTo<AlunoCursoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
