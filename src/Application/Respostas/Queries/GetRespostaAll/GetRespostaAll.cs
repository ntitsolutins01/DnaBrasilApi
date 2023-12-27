using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Respostas.Queries.GetRespostaAll;
//[Authorize]
public record GetRespostasAllQuery : IRequest<List<RespostaDto>>;

public class GetRespostasAllQueryHandler : IRequestHandler<GetRespostasAllQuery, List<RespostaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRespostasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RespostaDto>> Handle(GetRespostasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Respostas
            .AsNoTracking()
            .ProjectTo<RespostaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
