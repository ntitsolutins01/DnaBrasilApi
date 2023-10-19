using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.DeleteTalentoEsportivo;

public record DeleteTalentoEsportivoCommand : IRequest<int>
{
}

public class DeleteTalentoEsportivoCommandValidator : AbstractValidator<DeleteTalentoEsportivoCommand>
{
    public DeleteTalentoEsportivoCommandValidator()
    {
    }
}

public class DeleteTalentoEsportivoCommandHandler : IRequestHandler<DeleteTalentoEsportivoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteTalentoEsportivoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> Handle(DeleteTalentoEsportivoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
