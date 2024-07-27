using DnaBrasilApi.Application.Parceiros.Queries;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Parceiros.Queries.GetParceirosByFilter;

public record GetParceirosByFilterQuery : IRequest<List<ParceiroDto>>
{
    public SearchParceirosDto? Search { get; init; }
}

public class GetParceirosByFilterQueryHandler : IRequestHandler<GetParceirosByFilterQuery, List<ParceiroDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetParceirosByFilterQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ParceiroDto>> Handle(GetParceirosByFilterQuery request, CancellationToken cancellationToken)
    {
        var Parceiros = _context.Parceiros
            .AsNoTracking();

        var result = FilterParceiros(Parceiros, request.Search!)
            .ProjectTo<ParceiroDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken); ;

        return await (result ?? throw new ArgumentNullException(nameof(result)));
    }

    private IQueryable<Parceiro> FilterParceiros(IQueryable<Parceiro> Parceiros, SearchParceirosDto search)
    {
        if (!string.IsNullOrWhiteSpace(search.Nome))
            Parceiros = Parceiros.Where(u => u.Nome!.Contains(search.Nome));

        //TODO: Fabio favor verificar erro
        //if (!string.IsNullOrWhiteSpace(search.SoliticaoesContrato))
        //    Parceiros = Parceiros.Where(u => u.SoliticaoesContrato.Contains(search.SoliticaoesContrato));

        //TODO: DRK terminar

        return Parceiros;
    }
}
