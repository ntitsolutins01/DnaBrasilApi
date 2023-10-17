using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Estados.Queries.GetEstadosAll;

public record GetEstadosAllQuery : IRequest<EstadoDto>
{
}

public class GetEstadosAllQueryValidator : AbstractValidator<GetEstadosAllQuery>
{
    public GetEstadosAllQueryValidator()
    {
    }
}

public class GetEstadosAllQueryHandler : IRequestHandler<GetEstadosAllQuery, EstadoDto>
{
    private readonly IApplicationDbContext _context;

    public GetEstadosAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EstadoDto> Handle(GetEstadosAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
