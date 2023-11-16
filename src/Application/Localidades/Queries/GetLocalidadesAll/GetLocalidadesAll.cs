using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Localidades.Queries.GetLocalidadesAll;
//[Authorize]
public record GetLocalidadesAllQuery : IRequest<List<LocalidadeDto>>;

public class GetLocalidadesAllQueryHandler : IRequestHandler<GetLocalidadesAllQuery, List<LocalidadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLocalidadesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LocalidadeDto>> Handle(GetLocalidadesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Localidades
            .AsNoTracking()
            .ProjectTo<LocalidadeDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
