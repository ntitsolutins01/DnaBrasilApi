using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.AlunosCursos.Queries.GetAlunoCursoById;

public record GetAlunoCursoByIdQuery : IRequest<AlunoCursoDto>
{
    public required int Id { get; init; }
}

public class GetAlunoCursoByIdQueryHandler : IRequestHandler<GetAlunoCursoByIdQuery, AlunoCursoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlunoCursoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AlunoCursoDto> Handle(GetAlunoCursoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.AlunosCursos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<AlunoCursoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
