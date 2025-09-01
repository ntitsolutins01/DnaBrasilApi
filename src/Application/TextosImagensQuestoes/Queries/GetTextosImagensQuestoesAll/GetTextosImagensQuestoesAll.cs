using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosImagensQuestoes.Queries.GetTextosImagensQuestoesAll;
//[Authorize]
public record GetTextosImagensQuestoesAllQuery : IRequest<List<TextoImagemQuestaoDto>>;

public class GetTextosImagensQuestoesAllQueryHandler : IRequestHandler<GetTextosImagensQuestoesAllQuery, List<TextoImagemQuestaoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTextosImagensQuestoesAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TextoImagemQuestaoDto>> Handle(GetTextosImagensQuestoesAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TextosImagensQuestoes
            .AsNoTracking()
            .ProjectTo<TextoImagemQuestaoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
