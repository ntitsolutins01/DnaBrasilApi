using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.LinhasAcoes.Queries.GetLinhaAcaoById;

public record GetLinhaAcaoByIdQuery : IRequest<LinhaAcaoDto>
{
    public required int Id { get; init; }
}

public class GetLinhaAcaoByIdQueryHandler : IRequestHandler<GetLinhaAcaoByIdQuery, LinhaAcaoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLinhaAcaoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<LinhaAcaoDto> Handle(GetLinhaAcaoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.LinhasAcoes
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<LinhaAcaoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
