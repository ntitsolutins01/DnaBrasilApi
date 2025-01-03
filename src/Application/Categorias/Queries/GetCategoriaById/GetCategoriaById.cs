using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Categorias.Queries.GetCategoriaById;

public record GetCategoriaByIdQuery : IRequest<CategoriaDto>
{
    public required int Id { get; init; }
}

public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoriaDto> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categorias
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<CategoriaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
