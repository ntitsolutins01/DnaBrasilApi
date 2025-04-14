using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.ControlesFrequencias.Queries;

namespace DnaBrasilApi.Application.ControlesFrequencias.Queries.GetControlesFrequenciasByDisciplinaId;

public record GetControlesFrequenciasByDisciplinaIdQuery : IRequest<List<ControleFrequenciaDto>>
{
    public required int DisciplinaId { get; init; }
}

public class GetControlesFrequenciasByDisciplinaIdQueryHandler : IRequestHandler<GetControlesFrequenciasByDisciplinaIdQuery, List<ControleFrequenciaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesFrequenciasByDisciplinaIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleFrequenciaDto>> Handle(GetControlesFrequenciasByDisciplinaIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesFrequencias
            .Where(x => x.Disciplina.Id == request.DisciplinaId)
            .AsNoTracking()
            .ProjectTo<ControleFrequenciaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
