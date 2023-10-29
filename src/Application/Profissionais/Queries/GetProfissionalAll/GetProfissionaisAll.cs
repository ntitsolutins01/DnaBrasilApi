using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Profissionais.Queries.GetProfissionalAll;

public record GetProfissionaisAllCommand : IRequest<int>
{
}

public class GetProfissionaisAllCommandValidator : AbstractValidator<GetProfissionaisAllCommand>
{
    public GetProfissionaisAllCommandValidator()
    {
    }
}

public class GetProfissionaisAllCommandHandler : IRequestHandler<GetProfissionaisAllCommand, int>
{
    private readonly IApplicationDbContext _context;

    public GetProfissionaisAllCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(GetProfissionaisAllCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
