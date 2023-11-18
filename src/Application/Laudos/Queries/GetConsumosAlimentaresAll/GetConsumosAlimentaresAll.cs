using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Laudos.Queries;

namespace DnaBrasilApi.Application.ConsumosAlimentaresAll.Queries.GetConsumosAlimentaresAllAll;
//[Authorize]
public record GetConsumosAlimentaresAllQuery : IRequest<List<ConsumoAlimentarDto>>;

public class GetConsumosAlimentaresAllQueryHandler : IRequestHandler<GetConsumosAlimentaresAllQuery, List<ConsumoAlimentarDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetConsumosAlimentaresAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ConsumoAlimentarDto>> Handle(GetConsumosAlimentaresAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ConsumoAlimentares
            .AsNoTracking()
            .ProjectTo<ConsumoAlimentarDto>(_mapper.ConfigurationProvider)
            .OrderBy(o => o.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
