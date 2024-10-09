using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Mappings;
using DnaBrasilApi.Application.Common.Models;

namespace DnaBrasilApi.Application.Laudos.Queries.GetLaudosAll;
//[Authorize]
public record GetLaudosAllQuery : IRequest<PaginatedList<LaudoDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetLaudosAllQueryHandler : IRequestHandler<GetLaudosAllQuery, PaginatedList<LaudoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLaudosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<LaudoDto>> Handle(GetLaudosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Laudos
            .AsNoTracking()
            .ProjectTo<LaudoDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

