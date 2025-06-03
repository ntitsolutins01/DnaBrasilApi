using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Queries.GetAtividadeByLocalidadeId;
//[Authorize]
public record GetAtividadeByLocalidadeIdQuery : IRequest<List<AtividadeDto>>
{
    public required int LocalidadeId { get; init; }
}

public class GetAtividadeByLocalidadeIdQueryHandler : IRequestHandler<GetAtividadeByLocalidadeIdQuery, List<AtividadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAtividadeByLocalidadeIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AtividadeDto>> Handle(GetAtividadeByLocalidadeIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Atividades
            .Where(x => x.Localidade.Id == request.LocalidadeId)
            .AsNoTracking()
            .ProjectTo<AtividadeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result;
    }
}
