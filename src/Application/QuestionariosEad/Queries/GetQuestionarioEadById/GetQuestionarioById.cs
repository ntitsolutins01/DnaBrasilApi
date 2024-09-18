using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestionariosEad.Queries.GetQuestionarioEadById;

public record GetQuestionarioEadByIdQuery : IRequest<QuestionarioEadDto>
{
    public required int Id { get; init; }
}

public class GetQuestionarioEadByIdQueryHandler : IRequestHandler<GetQuestionarioEadByIdQuery, QuestionarioEadDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionarioEadByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<QuestionarioEadDto> Handle(GetQuestionarioEadByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QuestionariosEad
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<QuestionarioEadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
