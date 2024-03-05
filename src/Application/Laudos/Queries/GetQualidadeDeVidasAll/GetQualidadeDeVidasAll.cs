using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetQualidadeDeVidasAll;
//[Authorize]
public record GetQualidadeDeVidasAllQuery : IRequest<List<QualidadeDeVidaDto>>;

public class GetQualidadeDeVidasAllQueryHandler : IRequestHandler<GetQualidadeDeVidasAllQuery, List<QualidadeDeVidaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQualidadeDeVidasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QualidadeDeVidaDto>> Handle(GetQualidadeDeVidasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QualidadeDeVidas
            .AsNoTracking()
            .ProjectTo<QualidadeDeVidaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

