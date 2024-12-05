using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetSaudeById;

public record GetSaudeByIdQuery : IRequest<SaudeDto>
{
    public required int Id { get; init; }
}

public class GetSaudeByIdQueryHandler : IRequestHandler<GetSaudeByIdQuery, SaudeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSaudeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SaudeDto> Handle(GetSaudeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Saudes
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<SaudeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
