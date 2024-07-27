using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesAcessosAulas.Queries.GetControlesAcessosAulasAll;
//[Authorize]
public record GetControlesAcessosAulasAllQuery : IRequest<List<ControleAcessoAulaDto>>;

public class GetControlesAcessosAulasAllQueryHandler : IRequestHandler<GetControlesAcessosAulasAllQuery, List<ControleAcessoAulaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesAcessosAulasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleAcessoAulaDto>> Handle(GetControlesAcessosAulasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesAcessosAulas
            .AsNoTracking()
            .ProjectTo<ControleAcessoAulaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
