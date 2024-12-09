using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Fomentos.Queries.GetFomentoByLocalidadeId;

public record GetFomentoByLocalidadeIdQuery : IRequest<FomentoDto>
{
    public required int Id { get; init; }
}

public class GetFomentoByLocalidadeIdQueryHandler : IRequestHandler<GetFomentoByLocalidadeIdQuery, FomentoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFomentoByLocalidadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FomentoDto> Handle(GetFomentoByLocalidadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Fomentos
            .Where(x => x.Localidade.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<FomentoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
