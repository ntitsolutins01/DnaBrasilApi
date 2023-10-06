using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Municipios.Queries.GetMunicipios;

public record GetMunicipiosQuery : IRequest<MunicipioDto>
{
}

public class GetMunicipiosQueryValidator : AbstractValidator<GetMunicipiosQuery>
{
    public GetMunicipiosQueryValidator()
    {
    }
}

public class GetMunicipiosQueryHandler : IRequestHandler<GetMunicipiosQuery, MunicipioDto>
{
    private readonly IApplicationDbContext _context;

    public GetMunicipiosQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<MunicipioDto> Handle(GetMunicipiosQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
