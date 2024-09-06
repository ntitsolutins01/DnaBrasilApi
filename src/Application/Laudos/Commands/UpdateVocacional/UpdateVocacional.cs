using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateVocacional;

public record UpdateVocacionalCommand : IRequest <bool>
{
    public int Id { get; init; }
    public required string Resposta { get; init; }
}

public class UpdateVocacionalCommandHandler : IRequestHandler<UpdateVocacionalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateVocacionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateVocacionalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Vocacionais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Respostas = request.Resposta;

        await _context.SaveChangesAsync(cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
