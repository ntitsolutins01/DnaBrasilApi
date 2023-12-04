using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Estudantes.Queries.GetEstudanteById;

public record GetEstudanteByIdQuery : IRequest<EstudanteDto>
{
    public required int Id { get; init; }
}

public class GetEstudanteByIdQueryHandler : IRequestHandler<GetEstudanteByIdQuery, EstudanteDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEstudanteByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EstudanteDto> Handle(GetEstudanteByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Profissionais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<EstudanteDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
