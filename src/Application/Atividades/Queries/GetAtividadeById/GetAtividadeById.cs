using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Queries.GetAtividadeById;

public record GetAtividadeByIdQuery : IRequest<AtividadeDto>
{
    public required int Id { get; init; }
}

public class GetAtividadeByIdQueryHandler : IRequestHandler<GetAtividadeByIdQuery, AtividadeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAtividadeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AtividadeDto> Handle(GetAtividadeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Atividades
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<AtividadeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
