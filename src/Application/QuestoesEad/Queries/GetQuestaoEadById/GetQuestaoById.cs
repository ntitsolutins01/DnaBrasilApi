using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestionariosEad.Queries.GetQuestionarioEadById;

public record GetQuestionarioEadByIdQuery : IRequest<QuestaoEadDto>
{
    public required int Id { get; init; }
}

public class GetQuestionarioEadByIdQueryHandler : IRequestHandler<GetQuestionarioEadByIdQuery, QuestaoEadDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionarioEadByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<QuestaoEadDto> Handle(GetQuestionarioEadByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QuestoesEad
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<QuestaoEadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
