using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Localidades.Queries.GetLocalidadeById;

public record GetLocalidadeByIdQuery : IRequest<LocalidadeDto>
{
    public required int Id { get; init; }
}

public class GetLocalidadeByIdQueryHandler : IRequestHandler<GetLocalidadeByIdQuery, LocalidadeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLocalidadeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<LocalidadeDto> Handle(GetLocalidadeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Localidades
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<LocalidadeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
