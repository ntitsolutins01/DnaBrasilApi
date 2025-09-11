using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.GrauParentescos.Queries.GetGrauParentescosAll;
//[Authorize]
public record GetGrauParentescosAllQuery : IRequest<List<GrauParentescoDto>>;

public class GetGrauParentescosAllQueryHandler : IRequestHandler<GetGrauParentescosAllQuery, List<GrauParentescoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGrauParentescosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GrauParentescoDto>> Handle(GetGrauParentescosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.GrauParentescos
            .AsNoTracking()
            .ProjectTo<GrauParentescoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
