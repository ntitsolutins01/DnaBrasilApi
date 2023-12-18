using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Respostas.Queries.GetRespostaById;

public record GetRespostaByIdQuery : IRequest<RespostaDto>
{
    public required int Id { get; init; }
}

public class GetRespostaByIdQueryHandler : IRequestHandler<GetRespostaByIdQuery, RespostaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRespostaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RespostaDto> Handle(GetRespostaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Respostas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<RespostaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
