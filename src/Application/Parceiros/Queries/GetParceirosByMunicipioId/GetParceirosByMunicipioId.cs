using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Parceiros.Queries.GetParceirosByMunicipioId;
//[Authorize]
public record GetParceirosByMunicipioIdQuery : IRequest<List<ParceiroDto>>
{
    public required int MunicipioId { get; init; }
}

public class GetParceirosByMunicipioIdQueryHandler : IRequestHandler<GetParceirosByMunicipioIdQuery, List<ParceiroDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetParceirosByMunicipioIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ParceiroDto>> Handle(GetParceirosByMunicipioIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Parceiros
            .Where((ac => ac.Municipio!.Id == request.MunicipioId))
            .AsNoTracking()
            .ProjectTo<ParceiroDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
