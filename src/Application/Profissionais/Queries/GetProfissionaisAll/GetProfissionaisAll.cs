using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Profissionais.Queries.GetProfissionaisAll;
//[Authorize]
public record GetProfissionaisAllQuery : IRequest<List<ProfissionalDto>>;

public class GetProfissionaisAllQueryHandler : IRequestHandler<GetProfissionaisAllQuery, List<ProfissionalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProfissionaisAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProfissionalDto>> Handle(GetProfissionaisAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Profissionais
            .AsNoTracking()
            .ProjectTo<ProfissionalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result;
    }
}
