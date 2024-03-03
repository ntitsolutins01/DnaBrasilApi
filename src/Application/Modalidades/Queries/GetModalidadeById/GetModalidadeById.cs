using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Modalidades.Queries.GetModalidadeById;

public record GetModalidadeByIdQuery : IRequest<ModalidadeDto>
{
    public required int Id { get; init; }
}

public class GetModalidadeByIdQueryHandler : IRequestHandler<GetModalidadeByIdQuery, ModalidadeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModalidadeByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModalidadeDto> Handle(GetModalidadeByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Modalidades
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ModalidadeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
