using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TextosQuestoes.Commands.CreateTextoQuestao;

public record CreateTextoQuestaoCommand : IRequest<int>
{
    public required int QuestaoEadId{ get; init; }
    public string? Texto { get; init; }
    public Byte[]? Imagem { get; init; }
}

public class CreateTextoQuestaoCommandHandler : IRequestHandler<CreateTextoQuestaoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTextoQuestaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTextoQuestaoCommand request, CancellationToken cancellationToken)
    {
        var questao = await _context.QuestoesEad
            .FindAsync([request.QuestaoEadId], cancellationToken);

        Guard.Against.NotFound((int)request.QuestaoEadId!, questao);

        var entity = new TextoQuestao
        {
            QuestaoEad = questao,
            Texto = request.Texto,
            Imagem = request.Imagem
        };

        _context.TextosQuestoes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
