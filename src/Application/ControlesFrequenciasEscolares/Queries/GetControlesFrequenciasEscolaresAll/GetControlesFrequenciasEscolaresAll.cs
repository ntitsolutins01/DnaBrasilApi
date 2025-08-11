using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries.GetControlesFrequenciasEscolaresAll;
//[Authorize]
public record GetControlesFrequenciasEscolaresAllQuery : IRequest<List<ControleFrequenciaEscolarDto>>;

public class GetControlesFrequenciasEscolaresAllQueryHandler : IRequestHandler<GetControlesFrequenciasEscolaresAllQuery, List<ControleFrequenciaEscolarDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesFrequenciasEscolaresAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleFrequenciaEscolarDto>> Handle(GetControlesFrequenciasEscolaresAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesFrequenciasEscolares
            .AsNoTracking()
            .ProjectTo<ControleFrequenciaEscolarDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
