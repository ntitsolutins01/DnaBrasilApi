using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetLaudosAll;
//[Authorize]
public record GetLaudosAllQuery : IRequest<List<LaudoDto>>;

public class GetLaudosAllQueryHandler : IRequestHandler<GetLaudosAllQuery, List<LaudoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLaudosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LaudoDto>> Handle(GetLaudosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Laudos
            .AsNoTracking()
            .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.AlunoId)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

