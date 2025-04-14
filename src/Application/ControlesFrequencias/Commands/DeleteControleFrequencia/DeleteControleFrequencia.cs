using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequencias.Commands.DeleteControleFrequencia;
public record DeleteControleFrequenciaCommand(int Id) : IRequest<bool>;

public class DeleteControleFrequenciaCommandHandler : IRequestHandler<DeleteControleFrequenciaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteControleFrequenciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteControleFrequenciaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesFrequencias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound<ControleFrequencia>(request.Id.ToString(), entity);

        _context.ControlesFrequencias.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
