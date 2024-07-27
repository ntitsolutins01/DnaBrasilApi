using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalById;

public record GetProfissionalByIdQuery : IRequest<ProfissionalDto>
{
    public required int Id { get; init; }
}

public class GetProfissionalByIdQueryHandler : IRequestHandler<GetProfissionalByIdQuery, ProfissionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProfissionalByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProfissionalDto> Handle(GetProfissionalByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Profissionais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .Include(i=>i.Modalidades)
            .ProjectTo<ProfissionalDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
