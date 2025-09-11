using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.GrauParentescos.Queries.GetGrauParentescoById;

public record GetGrauParentescoByIdQuery : IRequest<GrauParentescoDto>
{
    public required int Id { get; init; }
}

public class GetGrauParentescoByIdQueryHandler : IRequestHandler<GetGrauParentescoByIdQuery, GrauParentescoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGrauParentescoByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GrauParentescoDto> Handle(GetGrauParentescoByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.GrauParentescos
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<GrauParentescoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
