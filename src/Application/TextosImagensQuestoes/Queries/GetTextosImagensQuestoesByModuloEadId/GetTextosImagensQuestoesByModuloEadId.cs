using System.Reflection.Metadata.Ecma335;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosImagensQuestoes.Queries.GetTextosImagensQuestoesByModuloEadId;

public record GetTextosImagensQuestoesByQuestaoEadIdQuery : IRequest<List<TextoImagemQuestaoDto>>
{
    public required int QuestaoEadId { get; init; }
}

public class GetTextosImagensQuestoesByQuestaoEadIdQueryHandler : IRequestHandler<GetTextosImagensQuestoesByQuestaoEadIdQuery, List<TextoImagemQuestaoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTextosImagensQuestoesByQuestaoEadIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TextoImagemQuestaoDto>> Handle(GetTextosImagensQuestoesByQuestaoEadIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TextosImagensQuestoes
            .Where(ac => ac.QuestaoEad.Id == request.QuestaoEadId)
            .Include(ac => ac.QuestaoEad)
            .AsNoTracking()
            .ProjectTo<TextoImagemQuestaoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
