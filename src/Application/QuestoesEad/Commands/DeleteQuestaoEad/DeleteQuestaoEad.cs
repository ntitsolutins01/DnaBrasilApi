using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestoesEad.Commands.DeleteQuestaoEad;
public record DeleteQuestaoEadCommand(int Id) : IRequest<bool>;

public class DeleteQuestaoEadCommandHandler : IRequestHandler<DeleteQuestaoEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteQuestaoEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteQuestaoEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QuestoesEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.QuestoesEad.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
