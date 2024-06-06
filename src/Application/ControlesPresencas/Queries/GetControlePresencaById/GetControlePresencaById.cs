using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries.GetControlePresencaById;

public record GetControlePresencaByIdQuery : IRequest<ControlePresencaDto>
{
    public required int Id { get; init; }
}

public class GetControlePresencaByIdQueryHandler : IRequestHandler<GetControlePresencaByIdQuery, ControlePresencaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControlePresencaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ControlePresencaDto> Handle(GetControlePresencaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesPresencas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ControlePresencaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
