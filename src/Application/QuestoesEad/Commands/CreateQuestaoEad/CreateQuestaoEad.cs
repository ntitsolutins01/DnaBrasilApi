using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.QuestoesEad.Commands.CreateQuestaoEad;
public record CreateQuestaoEadCommand : IRequest<int>
{
    public required string Pergunta { get; init; }
    public required string Referencia { get; init; }
    public required int Questao { get; init; }
    public required int AulaId { get; init; }
}

public class CreateQuestaoEadCommandHandler : IRequestHandler<CreateQuestaoEadCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateQuestaoEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateQuestaoEadCommand request, CancellationToken cancellationToken)
    {
        var aula = await _context.Aulas
            .FindAsync([request.AulaId], cancellationToken);

        Guard.Against.NotFound(request.AulaId, aula);

        var entity = new QuestaoEad
        {
            Enunciado = request.Pergunta,
            Referencia = request.Referencia,
            Questao = request.Questao,
            Aula = aula
        };

        _context.QuestoesEad.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
