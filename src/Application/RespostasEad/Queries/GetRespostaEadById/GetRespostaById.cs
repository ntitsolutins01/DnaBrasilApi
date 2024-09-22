using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.RespostasEad.Queries.GetRespostaEadById;

public record GetRespostaEadByIdQuery : IRequest<RespostaEadDto>
{
    public required int Id { get; init; }
}

public class GetRespostaEadByIdQueryHandler : IRequestHandler<GetRespostaEadByIdQuery, RespostaEadDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRespostaEadByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RespostaEadDto> Handle(GetRespostaEadByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.RespostasEad
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<RespostaEadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
