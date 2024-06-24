using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModulosEad.Queries.GetModuloEadById;

public record GetModuloEadByIdQuery : IRequest<ModuloEadDto>
{
    public required int Id { get; init; }
}

public class GetModuloEadByIdQueryHandler : IRequestHandler<GetModuloEadByIdQuery, ModuloEadDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModuloEadByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModuloEadDto> Handle(GetModuloEadByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ModulosEad
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ModuloEadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
