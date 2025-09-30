using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Responsaveis.Queries.GetResponsaveisAll;
//[Authorize]
public record GetResponsaveisAllQuery : IRequest<List<ResponsavelDto>>;

public class GetResponsaveisAllQueryHandler : IRequestHandler<GetResponsaveisAllQuery, List<ResponsavelDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetResponsaveisAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ResponsavelDto>> Handle(GetResponsaveisAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Responsaveis
            .Where(x=>x.Status)
            .AsNoTracking()
            .ProjectTo<ResponsavelDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
