using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Ambientes.Queries.GetAmbientesAll;

public record GetAmbientesAllQuery : IRequest<AmbienteDto>
{
}

public class GetAmbientesAllQueryValidator : AbstractValidator<GetAmbientesAllQuery>
{
    public GetAmbientesAllQueryValidator()
    {
    }
}

public class GetAmbientesAllQueryHandler : IRequestHandler<GetAmbientesAllQuery, AmbienteDto>
{
    private readonly IApplicationDbContext _context;

    public GetAmbientesAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public  Task<AmbienteDto> Handle(GetAmbientesAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
