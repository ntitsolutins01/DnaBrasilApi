using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Parceiros.Queries.GetParceiroByAspNetUserId;

public record GetParceiroByAspNetUserIdQuery : IRequest<ParceiroDto>
{
    public required string AspNetUserId { get; init; }
}

public class GetParceiroByAspNetUserIdQueryHandler : IRequestHandler<GetParceiroByAspNetUserIdQuery, ParceiroDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetParceiroByAspNetUserIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParceiroDto> Handle(GetParceiroByAspNetUserIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Parceiros
            .Where(x => x.AspNetUserId == request.AspNetUserId)
            .AsNoTracking()
            .ProjectTo<ParceiroDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
