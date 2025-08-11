using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries.GetControleFrequenciaEscolarById;

public record GetControleFrequenciaEscolarByIdQuery : IRequest<ControleFrequenciaEscolarDto>
{
    public required int Id { get; init; }
}

public class GetControleFrequenciaEscolarByIdQueryHandler : IRequestHandler<GetControleFrequenciaEscolarByIdQuery, ControleFrequenciaEscolarDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControleFrequenciaEscolarByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ControleFrequenciaEscolarDto> Handle(GetControleFrequenciaEscolarByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesFrequenciasEscolares
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ControleFrequenciaEscolarDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
