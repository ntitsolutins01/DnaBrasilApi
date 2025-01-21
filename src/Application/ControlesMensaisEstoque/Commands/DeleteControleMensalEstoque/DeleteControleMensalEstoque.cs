using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Commands.DeleteControleMensalEstoque;
public record DeleteControleMensalEstoqueCommand(int Id) : IRequest<bool>;

public class DeleteControleMensalEstoqueCommandHandler : IRequestHandler<DeleteControleMensalEstoqueCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteControleMensalEstoqueCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteControleMensalEstoqueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesMensaisEstoque
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ControlesMensaisEstoque.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
