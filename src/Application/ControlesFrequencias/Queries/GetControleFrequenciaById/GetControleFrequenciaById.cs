using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControleFrequenciaById;

public record GetControleFrequenciaByIdQuery : IRequest<ControleFrequenciaDto>
{
    public required int Id { get; init; }
}

public class GetControleFrequenciaByIdQueryHandler : IRequestHandler<GetControleFrequenciaByIdQuery, ControleFrequenciaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControleFrequenciaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ControleFrequenciaDto> Handle(GetControleFrequenciaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesFrequencias
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ControleFrequenciaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
