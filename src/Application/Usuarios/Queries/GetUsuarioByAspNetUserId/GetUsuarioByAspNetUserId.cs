using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Usuarios.Queries.GetUsuarioByAspNetUserId;
//[Authorize]
public record GetUsuarioByAspNetUserIdQuery : IRequest<UsuarioDto>
{
    public required string AspNetUserId { get; init; }
}

public class GetUsuarioByAspNetUserIdQueryHandler : IRequestHandler<GetUsuarioByAspNetUserIdQuery, UsuarioDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsuarioByAspNetUserIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsuarioDto> Handle(GetUsuarioByAspNetUserIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Usuarios
            .Where(x => x.AspNetUserId == request.AspNetUserId)
            .AsNoTracking()
            .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return result!;
    }
}

