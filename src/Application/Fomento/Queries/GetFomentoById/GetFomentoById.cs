using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Fomento.Queries.GetFomentoById;

public record GetFomentoByIdQuery : IRequest<FomentoDto>
{
    public required int Id { get; init; }
}

public class GetFomentoByIdQueryHandler : IRequestHandler<GetFomentoByIdQuery, FomentoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFomentoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FomentoDto> Handle(GetFomentoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Fomentos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<FomentoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
