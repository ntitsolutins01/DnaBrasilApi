using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.RespostasEad.Commands.DeleteRespostaEad;
public record DeleteRespostaEadCommand(int Id) : IRequest<bool>;

public class DeleteRespostaEadCommandHandler : IRequestHandler<DeleteRespostaEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteRespostaEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteRespostaEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RespostasEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.RespostasEad.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
