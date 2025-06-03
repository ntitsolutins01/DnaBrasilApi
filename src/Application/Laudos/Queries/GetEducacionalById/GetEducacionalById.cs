using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Queries.GetEducacionalById;

public record GetEducacionalByIdQuery : IRequest<EducacionalDto>
{
    public required int Id { get; init; }
}

public class GetEducacionalByIdQueryHandler : IRequestHandler<GetEducacionalByIdQuery, EducacionalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEducacionalByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EducacionalDto> Handle(GetEducacionalByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Educacionais
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<EducacionalDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
