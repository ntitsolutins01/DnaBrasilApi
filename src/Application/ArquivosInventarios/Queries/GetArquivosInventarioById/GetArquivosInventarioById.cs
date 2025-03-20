using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ArquivosInventarios.Queries.GetArquivosInventarioById;

public record GetArquivosInventarioByIdQuery : IRequest<ArquivosInventarioDto>
{
    public required int Id { get; init; }
}

public class GetArquivosInventarioByIdQueryHandler : IRequestHandler<GetArquivosInventarioByIdQuery, ArquivosInventarioDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArquivosInventarioByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ArquivosInventarioDto> Handle(GetArquivosInventarioByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ArquivosInventarios
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ArquivosInventarioDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
