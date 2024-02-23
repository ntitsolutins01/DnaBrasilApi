using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Modalidades.Queries.GetAmbientesAll;
//[Authorize]
public record GetModalidadesQuery : IRequest<List<ModalidadeDto>>;

public class GetModalidadesQueryHandler : IRequestHandler<GetModalidadesQuery, List<ModalidadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModalidadesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModalidadeDto>> Handle(GetModalidadesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Modalidades
            .AsNoTracking()
            .ProjectTo<ModalidadeDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
