using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlesPresencasByAlunoId;

public record GetControlesPresencasByAlunoIdQuery : IRequest<List<ControlePresencaDto>>
{
    public required int AlunoId { get; init; }
}

public class GetControlesPresencasByAlunoIdQueryHandler : IRequestHandler<GetControlesPresencasByAlunoIdQuery, List<ControlePresencaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlesPresencasByAlunoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ControlePresencaDto>> Handle(GetControlesPresencasByAlunoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesPresencas
            .Where(x => x.Aluno.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<ControlePresencaDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
