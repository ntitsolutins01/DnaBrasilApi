using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TextosImagensQuestoes.Commands.CreateTextoImagemQuestao;

public record CreateTextoImagemQuestaoCommand : IRequest<int>
{
    public required int QuestaoEadId { get; init; }
    public string? Tipo { get; init; }
    public string? TextoImagem { get; init; }
    public int Ordem { get; init; }
}

public class CreateTextoImagemQuestaoCommandHandler : IRequestHandler<CreateTextoImagemQuestaoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTextoImagemQuestaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTextoImagemQuestaoCommand request, CancellationToken cancellationToken)
    {
        var questao = await _context.QuestoesEad
            .FindAsync([request.QuestaoEadId], cancellationToken);

        Guard.Against.NotFound((int)request.QuestaoEadId!, questao);

        var entity = new TextoImagemQuestao
        {
            QuestaoEad = questao,
            TextoImagem = request.TextoImagem,
            Tipo = request.Tipo,
            Ordem = request.Ordem
        };

        _context.TextosImagensQuestoes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
