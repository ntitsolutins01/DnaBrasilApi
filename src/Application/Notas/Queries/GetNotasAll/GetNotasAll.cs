using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Notas.Queries.GetNotasAll;
//[Authorize]
public record GetNotasAllQuery : IRequest<List<NotaDto>>;

public class GetNotasAllQueryHandler : IRequestHandler<GetNotasAllQuery, List<NotaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNotasAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<NotaDto>> Handle(GetNotasAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Notas
            .AsNoTracking()
            .ProjectTo<NotaDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
