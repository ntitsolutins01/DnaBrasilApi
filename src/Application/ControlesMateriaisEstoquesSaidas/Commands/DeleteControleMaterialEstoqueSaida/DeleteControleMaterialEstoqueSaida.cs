using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.DeleteControleMaterialEstoqueSaida;
public record DeleteControleMaterialEstoqueSaidaCommand(int Id) : IRequest<bool>;

public class DeleteControleMaterialEstoqueSaidaCommandHandler : IRequestHandler<DeleteControleMaterialEstoqueSaidaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteControleMaterialEstoqueSaidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteControleMaterialEstoqueSaidaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesMateriaisEstoquesSaidas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ControlesMateriaisEstoquesSaidas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
