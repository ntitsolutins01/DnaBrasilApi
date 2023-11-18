using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalAll;
//[Authorize]
public record GetProfissionaisQuery : IRequest<List<ProfissionalDto>>;

public class GetProfissionaisQueryHandler : IRequestHandler<GetProfissionaisQuery, List<ProfissionalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProfissionaisQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProfissionalDto>> Handle(GetProfissionaisQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Profissionais
            .AsNoTracking()
            .ProjectTo<ProfissionalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
