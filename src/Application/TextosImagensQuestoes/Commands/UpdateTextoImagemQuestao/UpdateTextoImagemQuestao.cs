using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosImagensQuestoes.Commands.UpdateTextoImagemQuestao;

public record UpdateTextoImagemQuestaoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required int QuestaoEadId { get; init; }
    public string? Tipo { get; init; }
    public string? TextoImagem { get; init; }
    public int Ordem { get; init; }
}

public class UpdateTextoImagemQuestaoCommandHandler : IRequestHandler<UpdateTextoImagemQuestaoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTextoImagemQuestaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTextoImagemQuestaoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TextosImagensQuestoes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var questao = await _context.QuestoesEad
            .FindAsync([request.QuestaoEadId], cancellationToken);

        Guard.Against.NotFound((int)request.QuestaoEadId!, questao);

        entity.TextoImagem = request.TextoImagem;
        entity.Tipo = request.Tipo;
        entity.Ordem = request.Ordem;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
