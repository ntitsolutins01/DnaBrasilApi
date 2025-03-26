using DnaBrasilApi.Application.Aulas.Queries;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetPresencasByAlunoId;

public record GetPresencasByAlunoIdQuery : IRequest<List<AulaDto>>
{
    public required int AlunoId { get; init; }
}

public class GetPresencasByAlunoIdQueryHandler : IRequestHandler<GetPresencasByAlunoIdQuery, List<AulaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPresencasByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AulaDto>> Handle(GetPresencasByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosPresencas
            .Where(ac => ac.AlunoId == request.AlunoId)
            .Include(ac => ac.Aula)
            .AsNoTracking()
            .Select(ac => ac.Aula)
            .ProjectTo<AulaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result ?? throw new ArgumentNullException(nameof(result));
    }
}
