using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Respostas.Commands.CreateResposta;

public record CreateRespostaCommand : IRequest<int>
{
    public required string RespostaQuestionario { get; init; }
    public required int QuestionarioId { get; init; }
    public required int ValorPesoResposta { get; init; }
}

public class CreateRespostaCommandHandler : IRequestHandler<CreateRespostaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRespostaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRespostaCommand request, CancellationToken cancellationToken)
    {
        var questionario = await _context.Questionarios
            .FindAsync(new object[] { request.QuestionarioId }, cancellationToken);

        Guard.Against.NotFound(request.QuestionarioId, questionario);

        var entity = new Resposta
        {
            RespostaQuestionario = request.RespostaQuestionario,
            Questionario = questionario!,
            ValorPesoResposta = request.ValorPesoResposta
        };

        _context.Respostas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
