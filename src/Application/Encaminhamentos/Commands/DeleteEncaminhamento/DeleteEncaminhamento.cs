using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Encaminhamentos.Commands.DeleteEncaminhamento;
public record DeleteEncaminhamentoCommand(int Id) : IRequest<bool>;

public class DeleteEncaminhamentoCommandHandler : IRequestHandler<DeleteEncaminhamentoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEncaminhamentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEncaminhamentoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Encaminhamentos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Encaminhamentos.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
