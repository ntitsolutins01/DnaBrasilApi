using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.LinhasAcoes.Commands.DeleteLinhaAcao;
public record DeleteLinhaAcaoCommand(int Id) : IRequest<bool>;

public class DeleteLinhaAcaoCommandHandler : IRequestHandler<DeleteLinhaAcaoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteLinhaAcaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteLinhaAcaoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.LinhasAcoes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.LinhasAcoes.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
