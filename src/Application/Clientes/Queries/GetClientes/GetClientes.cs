using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Clientes.Queries.GetClientes;

public record GetClientesQuery : IRequest<ClienteDto>
{
}

public class GetClientesQueryValidator : AbstractValidator<GetClientesQuery>
{
    public GetClientesQueryValidator()
    {
    }
}

public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery, ClienteDto>
{
    private readonly IApplicationDbContext _context;

    public GetClientesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<ClienteDto> Handle(GetClientesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
