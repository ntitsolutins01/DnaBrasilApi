using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetDependenciasAll;
//[Authorize]
public record GetDependenciasAllQuery : IRequest<List<DependenciaDto>>;

public class GetDependenciasAllQueryHandler : IRequestHandler<GetDependenciasAllQuery, List<DependenciaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDependenciasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DependenciaDto>> Handle(GetDependenciasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Dependencias
            .AsNoTracking()
            .ProjectTo<DependenciaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}

