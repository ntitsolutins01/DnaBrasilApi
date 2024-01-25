using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Queries.GetDependenciaById;

public record GetDependenciaByIdQuery : IRequest<DependenciaDto>
{
    public required int Id { get; init; }
}

public class GetDependenciaByIdQueryHandler : IRequestHandler<GetDependenciaByIdQuery, DependenciaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDependenciaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DependenciaDto> Handle(GetDependenciaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.DependenciasOld
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<DependenciaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
