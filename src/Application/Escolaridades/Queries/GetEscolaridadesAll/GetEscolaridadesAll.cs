using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Escolaridades.Queries.GetEscolaridadesAll;
//[Authorize]
public record GetEscolaridadeQuery : IRequest<List<EscolaridadeDto>>;

public class GetEscolaridadeQueryHandler : IRequestHandler<GetEscolaridadeQuery, List<EscolaridadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEscolaridadeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EscolaridadeDto>> Handle(GetEscolaridadeQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Escolaridades
            .AsNoTracking()
            .ProjectTo<EscolaridadeDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Nome)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
