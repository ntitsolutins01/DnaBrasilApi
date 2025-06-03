using DnaBrasilApi.Application.Atividades.Queries;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetPresencasByAlunoId;

public record GetPresencasByAlunoIdQuery : IRequest<List<AtividadeDto>>
{
    public required int AlunoId { get; init; }
}

public class GetPresencasByAlunoIdQueryHandler : IRequestHandler<GetPresencasByAlunoIdQuery, List<AtividadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPresencasByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AtividadeDto>> Handle(GetPresencasByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosPresencas
            .Where(ac => ac.AlunoId == request.AlunoId)
            .Include(ac => ac.Atividade)
            .AsNoTracking()
            .Select(ac => ac.Atividade)
            .ProjectTo<AtividadeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result ?? throw new ArgumentNullException(nameof(result));
    }
}
