using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Deficiencias.Queries.GetDeficienciaById;

public record GetDeficienciaByIdQuery : IRequest<DeficienciaDto>
{
    public required int Id { get; init; }
}

public class GetDeficienciaByIdQueryHandler : IRequestHandler<GetDeficienciaByIdQuery, DeficienciaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDeficienciaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DeficienciaDto> Handle(GetDeficienciaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Deficiencias
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<DeficienciaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
