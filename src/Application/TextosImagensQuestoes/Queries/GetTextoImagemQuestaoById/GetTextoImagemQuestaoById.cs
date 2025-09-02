using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosImagensQuestoes.Queries.GetTextoImagemQuestaoById;

public record GetTextoImagemQuestaoByIdQuery : IRequest<TextoImagemQuestaoDto>
{
    public required int Id { get; init; }
}

public class GetTextoImagemQuestaoByIdQueryHandler : IRequestHandler<GetTextoImagemQuestaoByIdQuery, TextoImagemQuestaoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTextoImagemQuestaoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TextoImagemQuestaoDto> Handle(GetTextoImagemQuestaoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TextosImagensQuestoes
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<TextoImagemQuestaoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
