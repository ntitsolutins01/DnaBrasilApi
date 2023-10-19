using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.UpdateTalentoEsportivo;

public record UpdateTalentoEsportivoCommand : IRequest<int>
{
}

public class UpdateTalentoEsportivoCommandValidator : AbstractValidator<UpdateTalentoEsportivoCommand>
{
    public UpdateTalentoEsportivoCommandValidator()
    {
    }
}

public class UpdateTalentoEsportivoCommandHandler : IRequestHandler<UpdateTalentoEsportivoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateTalentoEsportivoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(UpdateTalentoEsportivoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
