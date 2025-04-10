using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Commands.DeleteModeloCarteirinha;
public record DeleteModeloCarteirinhaCommand(int Id) : IRequest<bool>;

public class DeleteModeloCarteirinhaCommandHandler : IRequestHandler<ModelosCarteirinhas.Commands.DeleteModeloCarteirinha.DeleteModeloCarteirinhaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteModeloCarteirinhaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(ModelosCarteirinhas.Commands.DeleteModeloCarteirinha.DeleteModeloCarteirinhaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ModelosCarteirinhas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ModelosCarteirinhas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
