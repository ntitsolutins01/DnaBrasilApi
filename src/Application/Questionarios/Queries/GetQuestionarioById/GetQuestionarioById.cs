using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Questionarios.Queries.GetQuestionarioById;

public record GetQuestionarioByIdQuery : IRequest<QuestionarioDto>
{
    public required int Id { get; init; }
}

public class GetQuestionarioByIdQueryHandler : IRequestHandler<GetQuestionarioByIdQuery, QuestionarioDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionarioByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<QuestionarioDto> Handle(GetQuestionarioByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Questionarios
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<QuestionarioDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
