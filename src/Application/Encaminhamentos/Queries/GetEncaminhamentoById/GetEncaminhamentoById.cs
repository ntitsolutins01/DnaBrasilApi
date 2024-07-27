using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Encaminhamentos.Queries.GetEncaminhamentoById;

public record GetEncaminhamentoByIdQuery : IRequest<EncaminhamentoDto>
{
    public required int Id { get; init; }
}

public class GetEncaminhamentoByIdQueryHandler : IRequestHandler<GetEncaminhamentoByIdQuery, EncaminhamentoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEncaminhamentoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EncaminhamentoDto> Handle(GetEncaminhamentoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Encaminhamentos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<EncaminhamentoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
