using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.MetricasImc.Commands.DeleteMetricaImc;
public record DeleteMetricaImcCommand(int Id) : IRequest<bool>;

public class DeleteMetricaImcCommandHandler : IRequestHandler<DeleteMetricaImcCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteMetricaImcCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMetricaImcCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.MetricasImc
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.MetricasImc.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
