using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunoAulasByAlunoId;
//[Authorize]
public record GetAlunoAulasByAlunoIdQuery : IRequest<List<AlunoAulaDto>>
{
    public required int AlunoId { get; init; }
}

public class GetAlunoAulasByAlunoIdQueryHandler : IRequestHandler<GetAlunoAulasByAlunoIdQuery, List<AlunoAulaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunoAulasByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoAulaDto>> Handle(GetAlunoAulasByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosAulas
            .Where((x => x.AlunoId == request.AlunoId))
            .AsNoTracking()
            .ProjectTo<AlunoAulaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
