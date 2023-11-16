using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.TipoLaudos.Queries.GetTipoLaudosAll;
//[Authorize]
public record GetTipoLaudosAllQuery : IRequest<List<TipoLaudoDto>>;

public class GetTipoLaudosAllQueryHandler : IRequestHandler<GetTipoLaudosAllQuery, List<TipoLaudoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTipoLaudosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TipoLaudoDto>> Handle(GetTipoLaudosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TipoLaudos
            .AsNoTracking()
            .ProjectTo<TipoLaudoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
