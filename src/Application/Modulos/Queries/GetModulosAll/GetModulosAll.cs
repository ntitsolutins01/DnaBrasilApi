using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Modulos.Queries.GetModulosAll;
//[Authorize]
public record GetModulosAllQuery : IRequest<List<ModuloDto>>;

public class GetModulosAllQueryHandler : IRequestHandler<GetModulosAllQuery, List<ModuloDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModulosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModuloDto>> Handle(GetModulosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Modulos
            .AsNoTracking()
            .ProjectTo<ModuloDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
