using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Questionarios.Queries.GetQuestionarioAll;
//[Authorize]
public record GetQuestionariosQuery : IRequest<List<QuestionarioDto>>;

public class GetQuestionariosQueryHandler : IRequestHandler<GetQuestionariosQuery, List<QuestionarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionariosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuestionarioDto>> Handle(GetQuestionariosQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Questionarios
            .AsNoTracking()
            .ProjectTo<QuestionarioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Tipo)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
