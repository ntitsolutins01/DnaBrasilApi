using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Queries.GetAtividadeAlunosByAtividadeId;
//[Authorize]
public record GetAtividadeAlunosByAtividadeIdQuery : IRequest<List<AtividadeAlunoDto>>
{
    public required int AtividadeId { get; init; }
}

public class GetAtividadeAlunosByAtividadeIdQueryHandler : IRequestHandler<GetAtividadeAlunosByAtividadeIdQuery, List<AtividadeAlunoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAtividadeAlunosByAtividadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AtividadeAlunoDto>> Handle(GetAtividadeAlunosByAtividadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AtividadeAlunos
            //.Include(i=>i.Aluno)
            .Where((x => x.AtividadeId == request.AtividadeId))
            .AsNoTracking()
            .ProjectTo<AtividadeAlunoDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
