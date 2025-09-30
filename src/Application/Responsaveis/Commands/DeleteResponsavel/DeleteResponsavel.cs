using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Responsaveis.Commands.DeleteResponsavel;
public record DeleteResponsavelCommand(int Id) : IRequest<bool>;

public class DeleteResponsavelCommandHandler : IRequestHandler<DeleteResponsavelCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteResponsavelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteResponsavelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Responsaveis
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Responsaveis.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
