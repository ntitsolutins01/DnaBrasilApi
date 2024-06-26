using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Provas.Queries.GetProvaById;

public record GetProvaByIdQuery : IRequest<ProvaDto>
{
    public required int Id { get; init; }
}

public class GetProvaByIdQueryHandler : IRequestHandler<GetProvaByIdQuery, ProvaDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProvaByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProvaDto> Handle(GetProvaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Provas
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ProvaDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
