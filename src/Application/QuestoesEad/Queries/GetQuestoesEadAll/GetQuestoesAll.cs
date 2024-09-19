using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestoesEad.Queries.GetQuestoesEadAll;
//[Authorize]
public record GetQuestoesEadAllQuery : IRequest<List<QuestaoEadDto>>;

public class GetQuestoesEadAllQueryHandler : IRequestHandler<GetQuestoesEadAllQuery, List<QuestaoEadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestoesEadAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuestaoEadDto>> Handle(GetQuestoesEadAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QuestoesEad
            .AsNoTracking()
            .ProjectTo<QuestaoEadDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
