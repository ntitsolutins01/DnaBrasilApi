using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetQualidadeVidaById;

public record GetQualidadeVidaByIdQuery : IRequest<QualidadeDeVidaDto>
{
    public required int Id { get; init; }
}

public class GetQualidadeVidaByIdQueryHandler : IRequestHandler<GetQualidadeVidaByIdQuery, QualidadeDeVidaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQualidadeVidaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<QualidadeDeVidaDto> Handle(GetQualidadeVidaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.QualidadeDeVidas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<QualidadeDeVidaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
