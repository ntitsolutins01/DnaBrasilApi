using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.LinhasAcoes.Queries.GetLinhasAcoesAll;
//[Authorize]
public record GetLinhasAcoesAllQuery : IRequest<List<LinhaAcaoDto>>;

public class GetLinhasAcoesAllQueryHandler : IRequestHandler<GetLinhasAcoesAllQuery, List<LinhaAcaoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLinhasAcoesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LinhaAcaoDto>> Handle(GetLinhasAcoesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.LinhasAcoes
            .AsNoTracking()
            .ProjectTo<LinhaAcaoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
