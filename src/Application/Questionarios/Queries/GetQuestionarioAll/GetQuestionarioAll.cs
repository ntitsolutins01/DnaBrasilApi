using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Questionarios.Queries.GetQuestionarioAll;
//[Authorize]
public record GetQuestionariosAllQuery : IRequest<List<QuestionarioDto>>;

public class GetQuestionariosAllQueryHandler : IRequestHandler<GetQuestionariosAllQuery, List<QuestionarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionariosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuestionarioDto>> Handle(GetQuestionariosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Questionarios
            .AsNoTracking()
            .ProjectTo<QuestionarioDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
