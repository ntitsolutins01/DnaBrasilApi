using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries.GetControleMaterialEstoqueSaidaById;

public record GetControleMaterialEstoqueSaidaByIdQuery : IRequest<ControleMaterialEstoqueSaidaDto>
{
    public required int Id { get; init; }
}

public class GetControleMaterialEstoqueSaidaByIdQueryHandler : IRequestHandler<GetControleMaterialEstoqueSaidaByIdQuery, ControleMaterialEstoqueSaidaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControleMaterialEstoqueSaidaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ControleMaterialEstoqueSaidaDto> Handle(GetControleMaterialEstoqueSaidaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMateriaisEstoquesSaidas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ControleMaterialEstoqueSaidaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
