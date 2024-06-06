using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Usuarios.Queries.GetUsuarioByCpf;
//[Authorize]
public record GetUsuarioByCpfQuery : IRequest<UsuarioDto>
{
    public required string Cpf { get; init; }
}

public class GetUsuarioByCpfQueryHandler : IRequestHandler<GetUsuarioByCpfQuery, UsuarioDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsuarioByCpfQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsuarioDto> Handle(GetUsuarioByCpfQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Usuarios
            .Where(x => x.CpfCnpj == request.Cpf)
            .AsNoTracking()
            .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        return result!;
    }
}

