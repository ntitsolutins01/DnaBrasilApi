using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestionariosEad.Queries.GetQuestionarioEadAll;
//[Authorize]
public record GetQuestionariosEadAllQuery : IRequest<List<QuestaoEadDto>>;

public class GetQuestionariosEadAllQueryHandler : IRequestHandler<GetQuestionariosEadAllQuery, List<QuestaoEadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionariosEadAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuestaoEadDto>> Handle(GetQuestionariosEadAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QuestoesEad
            .AsNoTracking()
            .ProjectTo<QuestaoEadDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
