using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Perfis.Queries.GetPerfilById;

public record GetPerfilByIdQuery : IRequest<PerfilDto>
{
    public required int Id { get; init; }
}

public class GetPerfilByIdQueryHandler : IRequestHandler<GetPerfilByIdQuery, PerfilDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPerfilByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PerfilDto> Handle(GetPerfilByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Perfis
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<PerfilDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
