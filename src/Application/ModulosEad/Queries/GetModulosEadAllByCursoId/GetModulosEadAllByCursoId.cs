using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModulosEad.Queries.GetModulosEadAllByCursoId;

public record GetModulosEadAllByCursoIdQuery : IRequest<List<ModuloEadDto>>
{
    public required int CursoId { get; init; }
}

public class GetModulosEadAllByCursoIdQueryHandler : IRequestHandler<GetModulosEadAllByCursoIdQuery, List<ModuloEadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModulosEadAllByCursoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModuloEadDto>> Handle(GetModulosEadAllByCursoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ModulosEad
            .Include(i=>i.Curso)
            //.Include(i=>i.Usuario)
            .Where(x => x.Curso.Id == request.CursoId)
            .AsNoTracking()
            .ProjectTo<ModuloEadDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
