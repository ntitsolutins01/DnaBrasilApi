using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Disciplinas.Queries.GetDisciplinaById;

public record GetDisciplinaByIdQuery : IRequest<DisciplinaDto>
{
    public required int Id { get; init; }
}

public class GetDisciplinaByIdQueryHandler : IRequestHandler<GetDisciplinaByIdQuery, DisciplinaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetDisciplinaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DisciplinaDto> Handle(GetDisciplinaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Disciplinas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<DisciplinaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
