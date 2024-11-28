using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosQuestoes.Commands.DeleteTextoQuestao;
public record DeleteTextoQuestaoCommand(int Id) : IRequest<bool>;

public class DeleteTextoQuestaoCommandHandler : IRequestHandler<DeleteTextoQuestaoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTextoQuestaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTextoQuestaoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TextosQuestoes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TextosQuestoes.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
