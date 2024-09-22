using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.RespostasEad.Queries.GetRespostasEadAll;
//[Authorize]
public record GetRespostasEadAllQuery : IRequest<List<RespostaEadDto>>;

public class GetRespostasEadAllQueryHandler : IRequestHandler<GetRespostasEadAllQuery, List<RespostaEadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRespostasEadAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RespostaEadDto>> Handle(GetRespostasEadAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.RespostasEad
            .AsNoTracking()
            .ProjectTo<RespostaEadDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
