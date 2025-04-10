using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Fomentos.Queries.GetFomentoLocalidadesByLocalidadeId;

public record GetFomentoLocalidadesByLocalidadeIdQuery : IRequest<FomentoDto>
{
    public required int Id { get; init; }
}

public class GetFomentoLocalidadesByLocalidadeIdQueryHandler : IRequestHandler<GetFomentoLocalidadesByLocalidadeIdQuery, FomentoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetFomentoLocalidadesByLocalidadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FomentoDto> Handle(GetFomentoLocalidadesByLocalidadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.FomentoLocalidades
            .Where(x => x.LocalidadeId == request.Id)
            .Select(s => s.Fomento)
            .ProjectTo<FomentoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
