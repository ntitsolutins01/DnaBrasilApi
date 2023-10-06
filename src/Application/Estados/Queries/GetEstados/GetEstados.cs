using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Estados.Queries.GetEstados;

public record GetEstadosQuery : IRequest<EstadoDto>
{
}

public class GetEstadosQueryValidator : AbstractValidator<GetEstadosQuery>
{
    public GetEstadosQueryValidator()
    {
    }
}

public class GetEstadosQueryHandler : IRequestHandler<GetEstadosQuery, EstadoDto>
{
    private readonly IApplicationDbContext _context;

    public GetEstadosQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<EstadoDto> Handle(GetEstadosQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
