using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Commands.UpdateQualidadeDeVida;

public record UpdateQualidadeDeVidaCommand : IRequest
{
    public int Id { get; init; }
    public required string Resposta { get; init; }
}

public class UpdateQualidadeDeVidaCommandHandler : IRequestHandler<UpdateQualidadeDeVidaCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateQualidadeDeVidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateQualidadeDeVidaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QualidadeDeVidas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Resposta = request.Resposta;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
