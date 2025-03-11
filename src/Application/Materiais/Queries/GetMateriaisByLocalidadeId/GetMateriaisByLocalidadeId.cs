using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Materiais.Queries.GetMateriaisByLocalidadeId;

public record GetMateriaisByLocalidadeIdQuery : IRequest<List<MaterialDto>>
{
    public required int LocalidadeId { get; init; }
}

public class GetMateriaisByLocalidadeIdQueryHandler : IRequestHandler<GetMateriaisByLocalidadeIdQuery, List<MaterialDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMateriaisByLocalidadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MaterialDto>> Handle(GetMateriaisByLocalidadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Materiais
            .Include(i => i.Localidade)
            .Where(x => x.Localidade!.Id == request.LocalidadeId)
            .AsNoTracking()
            .ProjectTo<MaterialDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
