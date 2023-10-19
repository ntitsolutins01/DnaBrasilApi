using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.CreateTalentoEsportivo;

public record CreateTalentoEsportivoCommand : IRequest<int>
{
}

public class CreateTalentoEsportivoCommandValidator : AbstractValidator<CreateTalentoEsportivoCommand>
{
    public CreateTalentoEsportivoCommandValidator()
    {
    }
}

public class CreateTalentoEsportivoCommandHandler : IRequestHandler<CreateTalentoEsportivoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTalentoEsportivoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(CreateTalentoEsportivoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
