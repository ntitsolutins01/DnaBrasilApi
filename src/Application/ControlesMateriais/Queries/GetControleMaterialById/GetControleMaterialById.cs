using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriais.Queries.GetControleMaterialById;

public record GetControleMaterialByIdQuery : IRequest<ControleMaterialDto>
{
    public required int Id { get; init; }
}

public class GetControleMaterialByIdQueryHandler : IRequestHandler<GetControleMaterialByIdQuery, ControleMaterialDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetControleMaterialByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ControleMaterialDto> Handle(GetControleMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.ControlesMateriais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ControleMaterialDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
