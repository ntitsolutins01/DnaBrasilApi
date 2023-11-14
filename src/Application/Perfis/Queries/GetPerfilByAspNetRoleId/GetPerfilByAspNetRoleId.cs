using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Perfis.Queries.GetPerfilByAspNetRoleId;

public record GetPerfilByAspNetRoleIdQuery : IRequest<PerfilDto>
{
    public required string AspNetRoleId { get; init; }
}

public class GetPerfilByAspNetRoleIdQueryHandler : IRequestHandler<GetPerfilByAspNetRoleIdQuery, PerfilDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPerfilByAspNetRoleIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PerfilDto> Handle(GetPerfilByAspNetRoleIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Perfis
            .Where(x => x.AspNetRoleId == request.AspNetRoleId)
            .AsNoTracking()
            .ProjectTo<PerfilDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
