using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Materiais.Queries.GetMaterialById;

public record GetMaterialByIdQuery : IRequest<MaterialDto>
{
    public required int Id { get; init; }
}

public class GetMaterialByIdQueryHandler : IRequestHandler<GetMaterialByIdQuery, MaterialDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMaterialByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MaterialDto> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Materiais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<MaterialDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
