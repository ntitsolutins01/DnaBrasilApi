using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Locais.Commands.DeleteLocal;
public record DeleteLocalCommand(int Id) : IRequest;

public class DeleteLocalCommandHandler : IRequestHandler<DeleteLocalCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteLocalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteLocalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Localidade
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Localidade.Remove(entity);

        //entity.AddDomainEvent(new LocalDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
