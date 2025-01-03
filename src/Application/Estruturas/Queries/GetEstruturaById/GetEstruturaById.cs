using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Estruturas.Queries.GetEstruturaById;

public record GetEstruturaByIdQuery : IRequest<EstruturaDto>
{
    public required int Id { get; init; }
}

public class GetEstruturaByIdQueryHandler : IRequestHandler<GetEstruturaByIdQuery, EstruturaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstruturaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EstruturaDto> Handle(GetEstruturaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Estruturas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<EstruturaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
