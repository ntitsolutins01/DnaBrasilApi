using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Queries.GetModelosCarteirinhasAll;
//[Authorize]
public record GetModelosCarteirinhasAllQuery : IRequest<List<ModeloCarteirinhaDto>>;

public class GetModelosCarteirinhasAllQueryHandler : IRequestHandler<GetModelosCarteirinhasAllQuery, List<ModeloCarteirinhaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModelosCarteirinhasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModeloCarteirinhaDto>> Handle(GetModelosCarteirinhasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ModelosCarteirinhas
            .AsNoTracking()
            .ProjectTo<ModeloCarteirinhaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
