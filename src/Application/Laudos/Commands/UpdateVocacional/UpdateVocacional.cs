using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Laudos.Commands.UpdateVocacional;

public record UpdateVocacionalCommand : IRequest
{
    public int Id { get; init; }
    public required string Resposta { get; init; }
}

public class UpdateVocacionalCommandHandler : IRequestHandler<UpdateVocacionalCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateVocacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateVocacionalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Vocacionais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Resposta = request.Resposta;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
