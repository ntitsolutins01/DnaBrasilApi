using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TipoCursos.Queries.GetTipoCursoById;

public record GetTipoCursoByIdQuery : IRequest<TipoCursoDto>
{
    public required int Id { get; init; }
}

public class GetTipoCursoByIdQueryHandler : IRequestHandler<GetTipoCursoByIdQuery, TipoCursoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTipoCursoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TipoCursoDto> Handle(GetTipoCursoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TipoCursos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<TipoCursoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
