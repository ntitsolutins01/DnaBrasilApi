using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Municipios.Queries.GetMunicipiosByUf;

public record GetMunicipioByUfQuery : IRequest<List<MunicipioDto>>
{
    public required string Uf { get; init; }
}

public class GetMunicipioByUfQueryHandler : IRequestHandler<GetMunicipioByUfQuery, List<MunicipioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMunicipioByUfQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MunicipioDto>> Handle(GetMunicipioByUfQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Municipios
            .Where(x => x.Estado!.Sigla == request.Uf)
            .AsNoTracking()
            .ProjectTo<MunicipioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result;
    }
}
