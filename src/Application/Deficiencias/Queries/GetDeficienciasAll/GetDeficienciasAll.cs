using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Deficiencias.Queries.GetDeficienciasAll;

public record GetDeficienciasAllQuery : IRequest<DeficienciaDto>
{
}

public class GetDeficienciasAllQueryValidator : AbstractValidator<GetDeficienciasAllQuery>
{
    public GetDeficienciasAllQueryValidator()
    {
    }
}

public class GetDeficienciasAllQueryHandler : IRequestHandler<GetDeficienciasAllQuery, DeficienciaDto>
{
    private readonly IApplicationDbContext _context;

    public GetDeficienciasAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<DeficienciaDto> Handle(GetDeficienciasAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
