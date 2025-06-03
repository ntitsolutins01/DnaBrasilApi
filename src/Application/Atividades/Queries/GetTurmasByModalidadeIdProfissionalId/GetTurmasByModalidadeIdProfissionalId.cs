using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Queries.GetTurmasByModalidadeIdProfissionalId;
//[Authorize]
public record GetTurmasByModalidadeIdProfissionalIdQuery : IRequest<List<AtividadeDto>>
{
    public required int ModalidadeId { get; init; }
    public required int ProfissionalId { get; init; }
}

public class GetTurmasByModalidadeIdProfissionalIdQueryHandler : IRequestHandler<GetTurmasByModalidadeIdProfissionalIdQuery, List<AtividadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTurmasByModalidadeIdProfissionalIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AtividadeDto>> Handle(GetTurmasByModalidadeIdProfissionalIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Atividades
            .Where(x => x.Profissional.Id == request.ProfissionalId && x.Modalidade.Id == request.ModalidadeId)
            .AsNoTracking()
            .ProjectTo<AtividadeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
