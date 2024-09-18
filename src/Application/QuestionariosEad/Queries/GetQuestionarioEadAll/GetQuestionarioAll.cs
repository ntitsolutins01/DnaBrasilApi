using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestionariosEad.Queries.GetQuestionarioEadAll;
//[Authorize]
public record GetQuestionariosEadAllQuery : IRequest<List<QuestionarioEadDto>>;

public class GetQuestionariosEadAllQueryHandler : IRequestHandler<GetQuestionariosEadAllQuery, List<QuestionarioEadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionariosEadAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuestionarioEadDto>> Handle(GetQuestionariosEadAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QuestionariosEad
            .AsNoTracking()
            .ProjectTo<QuestionarioEadDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
