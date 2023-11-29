using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Profissionais.Commands.DeleteProfissional;
public record DeleteProfissionalCommand(int Id) : IRequest<bool>;

public class DeleteProfissionalCommandHandler : IRequestHandler<DeleteProfissionalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteProfissionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProfissionalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TodoItems.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
