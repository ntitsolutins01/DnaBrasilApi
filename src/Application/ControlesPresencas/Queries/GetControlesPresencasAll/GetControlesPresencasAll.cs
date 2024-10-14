using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Mappings;
using DnaBrasilApi.Application.Common.Models;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasAll;
//[Authorize]
public record GetControlesPresencasAllQuery : IRequest<PaginatedList<ControlePresencaDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetControlesPresencasAllQueryHandler : IRequestHandler<GetControlesPresencasAllQuery, PaginatedList<ControlePresencaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesPresencasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ControlePresencaDto>> Handle(GetControlesPresencasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesPresencas
            .Include(i => i.Evento)
            .Where(x => x.Evento == null)
            .AsNoTracking()
            .ProjectTo<ControlePresencaDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
