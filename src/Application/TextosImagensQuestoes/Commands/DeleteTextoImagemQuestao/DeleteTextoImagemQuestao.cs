using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosImagensQuestoes.Commands.DeleteTextoImagemQuestao;
public record DeleteTextoImagemQuestaoCommand(int Id) : IRequest<bool>;

public class DeleteTextoImagemQuestaoCommandHandler : IRequestHandler<DeleteTextoImagemQuestaoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteTextoImagemQuestaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTextoImagemQuestaoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TextosImagensQuestoes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TextosImagensQuestoes.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
