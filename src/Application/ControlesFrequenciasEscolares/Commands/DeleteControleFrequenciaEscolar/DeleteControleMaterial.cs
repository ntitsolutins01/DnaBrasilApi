using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.DeleteControleFrequenciaEscolar;
public record DeleteControleFrequenciaEscolarCommand(int Id) : IRequest<bool>;

public class DeleteControleFrequenciaEscolarCommandHandler : IRequestHandler<DeleteControleFrequenciaEscolarCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteControleFrequenciaEscolarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteControleFrequenciaEscolarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesFrequenciasEscolares
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ControlesFrequenciasEscolares.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
