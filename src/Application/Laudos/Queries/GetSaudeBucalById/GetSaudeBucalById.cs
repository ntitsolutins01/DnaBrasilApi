using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetSaudeBucalById;

public record GetSaudeBucalByIdQuery : IRequest<SaudeBucalDto>
{
    public required int Id { get; init; }
}

public class GetSaudeBucalByIdQueryHandler : IRequestHandler<GetSaudeBucalByIdQuery, SaudeBucalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSaudeBucalByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SaudeBucalDto> Handle(GetSaudeBucalByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.SaudeBucais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<SaudeBucalDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
