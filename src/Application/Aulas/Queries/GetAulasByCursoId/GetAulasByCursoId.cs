using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Aulas.Queries.GetAulasByCursoId
{
    public record GetAulasByCursoIdQuery : IRequest<List<AulaDto>>
    {
        public required int CursoId { get; init; }
    }

    public class GetAulasByCursoIdQueryHandler : IRequestHandler<GetAulasByCursoIdQuery, List<AulaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAulasByCursoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AulaDto>> Handle(GetAulasByCursoIdQuery request, CancellationToken cancellationToken)
        {
            var moduloIds = await _context.ModulosEad
                .Where(m => m.Curso.Id == request.CursoId)
                .AsNoTracking()
                .Select(m => m.Id)
                .ToListAsync(cancellationToken);

            if (!moduloIds.Any())
            {
                return new List<AulaDto>();
            }

            var result = await _context.Aulas
                .Include(a => a.ModuloEad)
                .Where(a => moduloIds.Contains(a.ModuloEad.Id))
                .AsNoTracking()
                .OrderBy(t => t.Titulo)
                .ProjectTo<AulaDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
        }
    }
}
