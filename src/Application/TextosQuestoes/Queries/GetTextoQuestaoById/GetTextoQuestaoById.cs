using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosQuestoes.Queries.GetTextoQuestaoById;

public record GetTextoQuestaoByIdQuery : IRequest<TextoQuestaoDto>
{
    public required int Id { get; init; }
}

public class GetTextoQuestaoByIdQueryHandler : IRequestHandler<GetTextoQuestaoByIdQuery, TextoQuestaoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTextoQuestaoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TextoQuestaoDto> Handle(GetTextoQuestaoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TextosQuestoes
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<TextoQuestaoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
