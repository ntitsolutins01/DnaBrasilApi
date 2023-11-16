using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Escolaridades.Commands.DeleteEscolaridade;
public record DeleteEscolaridadeCommand(int Id) : IRequest<bool>;

public class DeleteEscolaridadeCommandHandler : IRequestHandler<DeleteEscolaridadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEscolaridadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEscolaridadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Escolaridades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Escolaridades.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
