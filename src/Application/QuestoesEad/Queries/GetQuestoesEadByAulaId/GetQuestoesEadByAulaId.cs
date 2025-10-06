using System.Reflection.Metadata.Ecma335;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestoesEad.Queries.GetQuestoesEadByAulaId;

public record GetQuestoesEadByAulaIdQuery : IRequest<List<QuestaoEadDto>>
{
    public required int AulaId { get; init; }
}

public class GetQuestoesEadByAulaIdQueryHandler : IRequestHandler<GetQuestoesEadByAulaIdQuery, List<QuestaoEadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestoesEadByAulaIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuestaoEadDto>> Handle(GetQuestoesEadByAulaIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QuestoesEad
            .Where(ac => ac.Aula.Id == request.AulaId)
            .Include(ac => ac.Aula)
            .AsNoTracking()
            .ProjectTo<QuestaoEadDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
