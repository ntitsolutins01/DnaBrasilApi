using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Locais.Queries.GetLocais;

public record GetLocaisQuery : IRequest<LocalDto>
{
}

public class GetLocaisQueryValidator : AbstractValidator<GetLocaisQuery>
{
    public GetLocaisQueryValidator()
    {
    }
}

public class GetLocaisQueryHandler : IRequestHandler<GetLocaisQuery, LocalDto>
{
    private readonly IApplicationDbContext _context;

    public GetLocaisQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<LocalDto> Handle(GetLocaisQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
