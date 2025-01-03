using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetVocacionalById;

public record GetVocacionalByIdQuery : IRequest<VocacionalDto>
{
    public required int Id { get; init; }
}

public class GetVocacionalByIdQueryHandler : IRequestHandler<GetVocacionalByIdQuery, VocacionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetVocacionalByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<VocacionalDto> Handle(GetVocacionalByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Vocacionais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<VocacionalDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
