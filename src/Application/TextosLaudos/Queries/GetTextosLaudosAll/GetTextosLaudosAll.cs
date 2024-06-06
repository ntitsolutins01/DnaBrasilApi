using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosLaudos.Queries.GetTextosLaudosAll;
//[Authorize]
public record GetTextosLaudosAllQuery : IRequest<List<TextoLaudoDto>>;

public class GetTextosLaudosAllQueryHandler : IRequestHandler<GetTextosLaudosAllQuery, List<TextoLaudoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTextosLaudosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TextoLaudoDto>> Handle(GetTextosLaudosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TextosLaudos
            .AsNoTracking()
            .ProjectTo<TextoLaudoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.NomeTipoLaudo)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
