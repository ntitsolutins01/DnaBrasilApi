using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Modulos.Queries.GetModulosAll;

namespace DnaBrasilApi.Application.Modulos.Queries.GetModuloById;

public record GetModuloByIdQuery : IRequest<ModuloDto>
{
    public required int Id { get; init; }
}

public class GetModuloByIdQueryHandler : IRequestHandler<GetModuloByIdQuery, ModuloDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModuloByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModuloDto> Handle(GetModuloByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Modulos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ModuloDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result!;
    }
}
