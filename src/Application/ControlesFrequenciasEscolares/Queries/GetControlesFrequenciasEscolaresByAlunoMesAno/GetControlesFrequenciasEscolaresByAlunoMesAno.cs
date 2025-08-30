using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries.GetControlesFrequenciasEscolaresByAlunoMesAno;

public record GetControlesFrequenciasEscolaresByAlunoMesAnoQuery : IRequest<List<ControleFrequenciaEscolarDto>>
{
    public required int AlunoId { get; init; }
    public required int Mes { get; init; }
    public required int Ano { get; init; }
}

public class GetControlesFrequenciasEscolaresByAlunoMesAnoQueryHandler : IRequestHandler<GetControlesFrequenciasEscolaresByAlunoMesAnoQuery, List<ControleFrequenciaEscolarDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesFrequenciasEscolaresByAlunoMesAnoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleFrequenciaEscolarDto>> Handle(GetControlesFrequenciasEscolaresByAlunoMesAnoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesFrequenciasEscolares
            .Where(x =>
                x.Aluno!.Id == request.AlunoId & 
                x.DataFrequencia!.Value.Month == request.Mes & 
                x.DataFrequencia!.Value.Year == request.Ano)
            .AsNoTracking()
            .ProjectTo<ControleFrequenciaEscolarDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
