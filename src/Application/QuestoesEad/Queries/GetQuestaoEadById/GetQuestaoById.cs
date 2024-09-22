using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestoesEad.Queries.GetQuestaoEadById;

public record GetQuestaoEadByIdQuery : IRequest<QuestaoEadDto>
{
    public required int Id { get; init; }
}

public class GetQuestaoEadByIdQueryHandler : IRequestHandler<GetQuestaoEadByIdQuery, QuestaoEadDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestaoEadByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<QuestaoEadDto> Handle(GetQuestaoEadByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QuestoesEad
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<QuestaoEadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
