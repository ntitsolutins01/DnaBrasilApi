using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Cursos.Queries.GetCursoById;

public record GetCursoByIdQuery : IRequest<CursoDto>
{
    public required int Id { get; init; }
}

public class GetCursoByIdQueryHandler : IRequestHandler<GetCursoByIdQuery, CursoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCursoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CursoDto> Handle(GetCursoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Cursos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<CursoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
