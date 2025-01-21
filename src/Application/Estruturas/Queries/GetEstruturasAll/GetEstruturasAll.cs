using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Estruturas.Queries.GetEstruturasAll;
//[Authorize]
public record GetEstruturasAllQuery : IRequest<List<EstruturaDto>>;

public class GetEstruturasAllQueryHandler : IRequestHandler<GetEstruturasAllQuery, List<EstruturaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstruturasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EstruturaDto>> Handle(GetEstruturasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Estruturas
            .AsNoTracking()
            .ProjectTo<EstruturaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
