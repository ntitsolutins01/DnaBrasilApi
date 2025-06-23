using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Security;
using DnaBrasilApi.Domain.Constants;

namespace DnaBrasilApi.Application.Series.Queries.GetSeriesAll;

[Authorize(Roles = Roles.Administrador)]
[Authorize(Roles = Roles.Gestor)]
[Authorize(Policy = Policies.Consultar)]
public record GetSeriesAllQuery : IRequest<List<SerieDto>>;

public class GetSeriesAllQueryHandler : IRequestHandler<GetSeriesAllQuery, List<SerieDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeriesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SerieDto>> Handle(GetSeriesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Series
            .AsNoTracking()
            .ProjectTo<SerieDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
