using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriais.Queries.GetControlesMateriaisAll;
//[Authorize]
public record GetControlesMateriaisAllQuery : IRequest<List<ControleMaterialDto>>;

public class GetControlesMateriaisAllQueryHandler : IRequestHandler<GetControlesMateriaisAllQuery, List<ControleMaterialDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesMateriaisAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleMaterialDto>> Handle(GetControlesMateriaisAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMateriais
            .AsNoTracking()
            .ProjectTo<ControleMaterialDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
