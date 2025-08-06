using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries.GetControlesFrequenciasEscolaresByAlunoId;

public record GetControlesFrequenciasEscolaresByAlunoIdQuery : IRequest<List<ControleFrequenciaEscolarDto>>
{
    public required int AlunoId { get; init; }
}

public class GetControlesFrequenciasEscolaresByAlunoIdQueryHandler : IRequestHandler<GetControlesFrequenciasEscolaresByAlunoIdQuery, List<ControleFrequenciaEscolarDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesFrequenciasEscolaresByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControleFrequenciaEscolarDto>> Handle(GetControlesFrequenciasEscolaresByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesFrequenciasEscolares
            .Include(i => i.Aluno)
            .Where(x => x.Aluno!.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<ControleFrequenciaEscolarDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
