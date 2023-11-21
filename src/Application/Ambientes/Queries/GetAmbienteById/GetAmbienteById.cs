using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Ambientes.Queries.GetAmbienteById;

public record GetAmbienteByIdQuery : IRequest<AmbienteDto>
{
    public required int Id { get; init; }
}

public class GetAmbienteByIdQueryHandler : IRequestHandler<GetAmbienteByIdQuery, AmbienteDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAmbienteByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AmbienteDto> Handle(GetAmbienteByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Ambientes
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<AmbienteDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
