using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModulosEad.Queries.GetModulosEadAll;
//[Authorize]
public record GetModulosEadAllQuery : IRequest<List<ModuloEadDto>>;

public class GetModulosEadAllQueryHandler : IRequestHandler<GetModulosEadAllQuery, List<ModuloEadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModulosEadAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModuloEadDto>> Handle(GetModulosEadAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ModulosEad
            .AsNoTracking()
            .ProjectTo<ModuloEadDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
