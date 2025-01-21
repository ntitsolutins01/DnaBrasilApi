using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Materiais.Queries.GetMateriaisAll;
//[Authorize]
public record GetMateriaisAllQuery : IRequest<List<MaterialDto>>;

public class GetMateriaisAllQueryHandler : IRequestHandler<GetMateriaisAllQuery, List<MaterialDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMateriaisAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MaterialDto>> Handle(GetMateriaisAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Materiais
            .AsNoTracking()
            .ProjectTo<MaterialDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
