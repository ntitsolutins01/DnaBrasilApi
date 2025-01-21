using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.GruposMateriais.Queries.GetGrupoMaterialById;

public record GetGrupoMaterialByIdQuery : IRequest<GrupoMaterialDto>
{
    public required int Id { get; init; }
}

public class GetGrupoMaterialByIdQueryHandler : IRequestHandler<GetGrupoMaterialByIdQuery, GrupoMaterialDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGrupoMaterialByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GrupoMaterialDto> Handle(GetGrupoMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.GruposMateriais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<GrupoMaterialDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
