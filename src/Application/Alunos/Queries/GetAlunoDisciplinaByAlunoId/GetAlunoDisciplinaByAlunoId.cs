using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetAlunoDisciplinaByAlunoId;
//[Authorize]
public record GetAlunoDisciplinasByAlunoIdQuery : IRequest<List<AlunoDisciplinaDto>>
{
    public required int AlunoId { get; init; }
}

public class GetAlunoDisciplinasByAlunoIdQueryHandler : IRequestHandler<GetAlunoDisciplinasByAlunoIdQuery, List<AlunoDisciplinaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunoDisciplinasByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AlunoDisciplinaDto>> Handle(GetAlunoDisciplinasByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosDisciplinas
            .Where((x => x.AlunoId == request.AlunoId))
            .AsNoTracking()
            .ProjectTo<AlunoDisciplinaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
