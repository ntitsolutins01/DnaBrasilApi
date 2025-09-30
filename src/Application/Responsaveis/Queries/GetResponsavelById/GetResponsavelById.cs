using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Responsaveis.Queries.GetResponsavelById;

public record GetResponsavelByIdQuery : IRequest<ResponsavelDto>
{
    public required int Id { get; init; }
}

public class GetResponsavelByIdQueryHandler : IRequestHandler<GetResponsavelByIdQuery, ResponsavelDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetResponsavelByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponsavelDto> Handle(GetResponsavelByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Responsaveis
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<ResponsavelDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
