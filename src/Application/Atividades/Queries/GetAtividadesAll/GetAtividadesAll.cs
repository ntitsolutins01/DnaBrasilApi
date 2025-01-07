using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Queries.GetAtividadesAll;
//[Authorize]
public record GetAtividadesAllQuery : IRequest<List<AtividadeDto>>;

public class GetAtividadesAllQueryHandler : IRequestHandler<GetAtividadesAllQuery, List<AtividadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAtividadesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AtividadeDto>> Handle(GetAtividadesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Atividades
            .AsNoTracking()
            .ProjectTo<AtividadeDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
