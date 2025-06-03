using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Queries.GetAtividadeByModalidadeIdProfissionalIdTurma;
//[Authorize]
public record GetAtividadeByModalidadeIdProfissionalIdTurmaQuery : IRequest<List<AtividadeDto>>
{
    public required int ModalidadeId { get; init; }
    public required int ProfissionalId { get; init; }
    public required string Turma { get; init; }
}

public class GetAtividadeByModalidadeIdProfissionalIdTurmaQueryHandler : IRequestHandler<GetAtividadeByModalidadeIdProfissionalIdTurmaQuery, List<AtividadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAtividadeByModalidadeIdProfissionalIdTurmaQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AtividadeDto>> Handle(GetAtividadeByModalidadeIdProfissionalIdTurmaQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Atividades
            .Where(x => x.Profissional.Id == request.ProfissionalId
                        && x.Modalidade.Id == request.ModalidadeId
                        && x.Turma == request.Turma)
            .AsNoTracking()
            .ProjectTo<AtividadeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
