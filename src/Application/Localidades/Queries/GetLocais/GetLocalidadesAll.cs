using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Locais.Queries.GetLocais;
//[Authorize]
public record GetLocalidadesAllQuery : IRequest<List<LocalDto>>;

public class GetLocalidadesAllQueryHandler : IRequestHandler<GetLocalidadesAllQuery, List<LocalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLocalidadesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LocalDto>> Handle(GetLocalidadesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Localidades
            .AsNoTracking()
            .ProjectTo<LocalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
