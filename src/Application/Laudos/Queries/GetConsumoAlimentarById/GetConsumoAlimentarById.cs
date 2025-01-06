using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetConsumoAlimentarById;

public record GetConsumoAlimentarByIdQuery : IRequest<ConsumoAlimentarDto>
{
    public required int Id { get; init; }
}

public class GetConsumoAlimentarByIdQueryHandler : IRequestHandler<GetConsumoAlimentarByIdQuery, ConsumoAlimentarDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetConsumoAlimentarByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ConsumoAlimentarDto> Handle(GetConsumoAlimentarByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ConsumoAlimentares
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ConsumoAlimentarDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
