using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Contratos.Queries.GetContratoById;

public record GetContratoByIdQuery : IRequest<ContratoDto>
{
    public required int Id { get; init; }
}

public class GetContratoByIdQueryHandler : IRequestHandler<GetContratoByIdQuery, ContratoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetContratoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ContratoDto> Handle(GetContratoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Contratos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ContratoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
