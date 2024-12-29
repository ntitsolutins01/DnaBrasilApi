using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TiposMateriais.Queries.GetTipoMaterialById;

public record GetTipoMaterialByIdQuery : IRequest<TipoMaterialDto>
{
    public required int Id { get; init; }
}

public class GetTipoMaterialByIdQueryHandler : IRequestHandler<GetTipoMaterialByIdQuery, TipoMaterialDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTipoMaterialByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TipoMaterialDto> Handle(GetTipoMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TiposMateriais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<TipoMaterialDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
