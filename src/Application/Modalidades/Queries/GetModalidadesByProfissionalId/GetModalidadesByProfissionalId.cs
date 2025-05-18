using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Modalidades.Queries.GetModalidadesByProfissionalId;
//[Authorize]
public record GetModalidadesByProfissionalIdQuery : IRequest<List<ModalidadeDto>>
{
    public required int ProfissionalId { get; init; }
}

public class GetModalidadesByProfissionalIdQueryHandler : IRequestHandler<GetModalidadesByProfissionalIdQuery, List<ModalidadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModalidadesByProfissionalIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModalidadeDto>> Handle(GetModalidadesByProfissionalIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ProfissionalModalidades
            .Where(x => x.ProfissionalId == request.ProfissionalId)
            .Include(i => i.Modalidade)
            .Select(s => s.Modalidade)
            //.AsNoTracking()
            .ProjectTo<ModalidadeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
