using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Usuarios.Queries.GetUsuarioById;

public record GetUsuarioByIdQuery : IRequest<UsuarioDto>
{
    public required int Id { get; init; }
}

public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsuarioByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsuarioDto> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Usuarios
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result! == null ? throw new ArgumentNullException(nameof(result)) : result;
    }
}
