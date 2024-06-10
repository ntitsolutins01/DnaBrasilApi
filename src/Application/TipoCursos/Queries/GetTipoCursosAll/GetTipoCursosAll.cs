using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TipoCursos.Queries.GetTipoCursosAll;
//[Authorize]
public record GetTipoCursosAllQuery : IRequest<List<TipoCursoDto>>;

public class GetTipoCursosAllQueryHandler : IRequestHandler<GetTipoCursosAllQuery, List<TipoCursoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTipoCursosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TipoCursoDto>> Handle(GetTipoCursosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TipoCursos
            .AsNoTracking()
            .ProjectTo<TipoCursoDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
