using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TipoLaudos.Queries.GetTipoLaudoById;

public record GetTipoLaudoByIdQuery : IRequest<TipoLaudoDto>
{
    public required int Id { get; init; }
}

public class GetTipoLaudoByIdQueryHandler : IRequestHandler<GetTipoLaudoByIdQuery, TipoLaudoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTipoLaudoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TipoLaudoDto> Handle(GetTipoLaudoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.TipoLaudos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<TipoLaudoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
