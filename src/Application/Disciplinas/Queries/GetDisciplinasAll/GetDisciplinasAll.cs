using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Disciplinas.Queries.GetDisciplinasAll;
//[Authorize]
public record GetDisciplinasAllQuery : IRequest<List<DisciplinaDto>>;

public class GetDisciplinasAllQueryHandler : IRequestHandler<GetDisciplinasAllQuery, List<DisciplinaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDisciplinasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DisciplinaDto>> Handle(GetDisciplinasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Disciplinas
            .AsNoTracking()
            .ProjectTo<DisciplinaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
