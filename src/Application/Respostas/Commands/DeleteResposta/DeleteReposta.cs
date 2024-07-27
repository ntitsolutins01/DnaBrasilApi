using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Respostas.Commands.DeleteResposta;
public record DeleteRespostaCommand(int Id) : IRequest<bool>;

public class DeleteRespostaCommandHandler : IRequestHandler<Respostas.Commands.DeleteResposta.DeleteRespostaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteRespostaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(Respostas.Commands.DeleteResposta.DeleteRespostaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Respostas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Respostas.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
