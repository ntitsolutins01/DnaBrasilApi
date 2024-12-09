using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosQuestoes.Queries.GetTextosQuestoesAll;
//[Authorize]
public record GetTextosQuestoesAllQuery : IRequest<List<TextoQuestaoDto>>;

public class GetTextosQuestoesAllQueryHandler : IRequestHandler<GetTextosQuestoesAllQuery, List<TextoQuestaoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTextosQuestoesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TextoQuestaoDto>> Handle(GetTextosQuestoesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TextosQuestoes
            .AsNoTracking()
            .ProjectTo<TextoQuestaoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
