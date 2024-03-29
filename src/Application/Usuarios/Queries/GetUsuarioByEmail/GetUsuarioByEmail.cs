using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Usuarios.Queries.GetUsuarioByEmail;
//[Authorize]
public record GetUsuarioByEmailQuery : IRequest<UsuarioDto>
{
    public required string Email { get; init; }
}

public class GetUsuarioByEmailQueryHandler : IRequestHandler<GetUsuarioByEmailQuery, UsuarioDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsuarioByEmailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsuarioDto> Handle(GetUsuarioByEmailQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Usuarios
            .Where(x => x.Email == request.Email)
            .AsNoTracking()
            .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return result!;
    }
}

