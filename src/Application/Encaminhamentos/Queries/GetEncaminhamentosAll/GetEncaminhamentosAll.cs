using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Encaminhamentos.Queries.GetEncaminhamentosAll;
//[Authorize]
public record GetEncaminhamentosAllQuery : IRequest<List<EncaminhamentoDto>>;

public class GetEncaminhamentosAllQueryHandler : IRequestHandler<GetEncaminhamentosAllQuery, List<EncaminhamentoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EncaminhamentoDto>> Handle(GetEncaminhamentosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Encaminhamentos
            .AsNoTracking()
            .ProjectTo<EncaminhamentoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
