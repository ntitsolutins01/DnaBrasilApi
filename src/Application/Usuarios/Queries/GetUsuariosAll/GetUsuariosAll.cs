using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.Usuarios.Queries.GetUsuarioAll;

namespace DnaBrasil.Application.Usuarios.Queries.GetUsuariosAll;
//[Authorize]
public record GetUsuariosAllQuery : IRequest<List<UsuarioDto>>;

public class GetUsuariosAllQueryHandler : IRequestHandler<GetUsuariosAllQuery, List<UsuarioDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsuariosAllQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UsuarioDto>> Handle(GetUsuariosAllQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Usuarios
            .AsNoTracking()
            .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .ToListAsync(cancellationToken);

        return result == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
