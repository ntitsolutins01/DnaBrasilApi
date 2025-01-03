using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosQuestoes.Commands.UpdateTextoQuestao;

public record UpdateTextoQuestaoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? Texto { get; init; }
    public Byte[]? Imagem { get; init; }
}

public class UpdateTextoQuestaoCommandHandler : IRequestHandler<UpdateTextoQuestaoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTextoQuestaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTextoQuestaoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TextosQuestoes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Texto = request.Texto;
        entity.Imagem = request.Imagem;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
