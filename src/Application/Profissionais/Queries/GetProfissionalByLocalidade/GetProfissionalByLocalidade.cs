using DnaBrasilApi.Application.Common.Interfaces;


namespace DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalByLocalidade;
//[Authorize]
public record GetProfissionalByLocalidadeQuery : IRequest<List<ProfissionalDto>>
{
    public required int LocalidadeId { get; init; }
}

public class GetProfissionalByLocalidadeQueryHandler : IRequestHandler<GetProfissionalByLocalidadeQuery, List<ProfissionalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProfissionalByLocalidadeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProfissionalDto>> Handle(GetProfissionalByLocalidadeQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Profissionais
            .Where(x => x.Localidade!.Id == request.LocalidadeId)
            .AsNoTracking()
            .ProjectTo<ProfissionalDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);
        
        return result;
    }
}

