using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Municipios.Queries.GetMunicipiosAll;

public record GetMunicipiosAllQuery : IRequest<MunicipioDto>
{
}

public class GetMunicipiosAllQueryValidator : AbstractValidator<GetMunicipiosAllQuery>
{
    public GetMunicipiosAllQueryValidator()
    {
    }
}

public class GetMunicipiosAllQueryHandler : IRequestHandler<GetMunicipiosAllQuery, MunicipioDto>
{
    private readonly IApplicationDbContext _context;

    public GetMunicipiosAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MunicipioDto> Handle(GetMunicipiosAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
