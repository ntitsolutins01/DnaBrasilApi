using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesAcessosAulas.Queries.GetControleAcessoAulaById;

public record GetControleAcessoAulaByIdQuery : IRequest<ControleAcessoAulaDto>
{
    public required int Id { get; init; }
}

public class GetControleAcessoAulaByIdQueryHandler : IRequestHandler<GetControleAcessoAulaByIdQuery, ControleAcessoAulaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControleAcessoAulaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ControleAcessoAulaDto> Handle(GetControleAcessoAulaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesAcessosAulas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ControleAcessoAulaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
