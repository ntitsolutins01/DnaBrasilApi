using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Modalidades.Queries.GetModalidadesByLinhaAcaoId;
//[Authorize]
public record GetModalidadesByLinhaAcaoIdQuery : IRequest<List<ModalidadeDto>>
{
    public required int LinhaAcaoId { get; init; }
}

public class GetModalidadesByLinhaAcaoIdQueryHandler : IRequestHandler<GetModalidadesByLinhaAcaoIdQuery, List<ModalidadeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModalidadesByLinhaAcaoIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ModalidadeDto>> Handle(GetModalidadesByLinhaAcaoIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Modalidades
            .Where(x => x.LinhaAcao!.Id == request.LinhaAcaoId)
            .AsNoTracking()
            .ProjectTo<ModalidadeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
