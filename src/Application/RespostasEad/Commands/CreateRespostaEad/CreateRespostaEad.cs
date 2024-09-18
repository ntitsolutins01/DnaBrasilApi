using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.RespostasEad.Commands.CreateRespostaEad;

public record CreateRespostaEadCommand : IRequest<int>
{
    public required int QuestaoId { get; init; }
    public required string TipoResposta { get; init; }
    public string? TipoAlternativa { get; init; }
    public required string Resposta { get; init; }
    public required decimal ValorPesoResposta { get; init; }
}

public class CreateRespostaEadCommandHandler : IRequestHandler<CreateRespostaEadCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRespostaEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRespostaEadCommand request, CancellationToken cancellationToken)
    {
        var questao = await _context.QuestoesEad
            .FindAsync(new object[] { request.QuestaoId }, cancellationToken);

        Guard.Against.NotFound(request.QuestaoId, questao);

        var entity = new RespostaEad
        {
            Questao = questao,
            TipoResposta = request.TipoResposta,
            TipoAlternativa = request.TipoAlternativa,
            Resposta = request.Resposta,
            ValorPesoResposta = request.ValorPesoResposta
        };

        _context.RespostasEad.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
