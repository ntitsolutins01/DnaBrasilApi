using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Municipios.Queries.GetMunicipioById;

public record GetMunicipioByIdQuery : IRequest<MunicipioDto>
{
    public required int Id { get; init; }
}

public class GetMunicipioByIdQueryHandler : IRequestHandler<GetMunicipioByIdQuery, MunicipioDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMunicipioByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MunicipioDto> Handle(GetMunicipioByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Municipios
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<MunicipioDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
