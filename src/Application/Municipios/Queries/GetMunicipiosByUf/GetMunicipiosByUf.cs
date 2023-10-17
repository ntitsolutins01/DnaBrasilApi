using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Municipios.Queries.GetMunicipiosByUf;

public record GetMunicipiosByUfQuery : IRequest<MunicipioDto>
{
}

public class GetMunicipiosByUfQueryValidator : AbstractValidator<GetMunicipiosByUfQuery>
{
    public GetMunicipiosByUfQueryValidator()
    {
    }
}

public class GetMunicipiosByUfQueryHandler : IRequestHandler<GetMunicipiosByUfQuery, MunicipioDto>
{
    private readonly IApplicationDbContext _context;

    public GetMunicipiosByUfQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MunicipioDto> Handle(GetMunicipiosByUfQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
