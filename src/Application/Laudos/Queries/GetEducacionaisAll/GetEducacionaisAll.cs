using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEducacionaisAll;
//[Authorize]
public record GetEducacionaisAllQuery : IRequest<List<EducacionalDto>>;

public class GetEducacionaisAllQueryHandler : IRequestHandler<GetEducacionaisAllQuery, List<EducacionalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEducacionaisAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EducacionalDto>> Handle(GetEducacionaisAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Educacionais
            .AsNoTracking()
            .ProjectTo<EducacionalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
