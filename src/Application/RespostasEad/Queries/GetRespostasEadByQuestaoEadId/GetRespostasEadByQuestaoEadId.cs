using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.RespostasEad.Queries.GetRespostasEadByQuestaoEadId;

public record GetRespostasEadByQuestaoEadIdQuery : IRequest<List<RespostaEadDto>>
{
    public required int QuestaoEadId { get; init; }
}

public class GetRespostasEadByQuestaoEadIdQueryHandler : IRequestHandler<GetRespostasEadByQuestaoEadIdQuery, List<RespostaEadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRespostasEadByQuestaoEadIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RespostaEadDto>> Handle(GetRespostasEadByQuestaoEadIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.RespostasEad
            .Where(ac => ac.Questao.Id == request.QuestaoEadId)
            .AsNoTracking()
            .ProjectTo<RespostaEadDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
