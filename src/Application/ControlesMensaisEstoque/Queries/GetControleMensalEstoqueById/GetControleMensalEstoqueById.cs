using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Queries.GetControleMensalEstoqueById;

public record GetControleMensalEstoqueByIdQuery : IRequest<ControleMensalEstoqueDto>
{
    public required int Id { get; init; }
}

public class GetControleMensalEstoqueByIdQueryHandler : IRequestHandler<GetControleMensalEstoqueByIdQuery, ControleMensalEstoqueDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControleMensalEstoqueByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ControleMensalEstoqueDto> Handle(GetControleMensalEstoqueByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMensaisEstoque
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ControleMensalEstoqueDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
