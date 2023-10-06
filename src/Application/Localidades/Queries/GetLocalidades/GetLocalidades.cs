using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Localidades.Queries.GetLocalidades;

public record GetLocalidadessQuery : IRequest<LocalidadeDto>
{
}

public class GetLocalidadessQueryValidator : AbstractValidator<GetLocalidadessQuery>
{
    public GetLocalidadessQueryValidator()
    {
    }
}

public class GetLocalidadessQueryHandler : IRequestHandler<GetLocalidadessQuery, LocalidadeDto>
{
    private readonly IApplicationDbContext _context;

    public GetLocalidadessQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<LocalidadeDto> Handle(GetLocalidadessQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
