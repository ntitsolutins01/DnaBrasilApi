using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Parceiros.Queries.GetParceiroById;

public record GetParceiroByIdQuery : IRequest<ParceiroDto>
{
    public required int Id { get; init; }
}

public class GetParceiroByIdQueryHandler : IRequestHandler<GetParceiroByIdQuery, ParceiroDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetParceiroByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParceiroDto> Handle(GetParceiroByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Parceiros
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ParceiroDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
