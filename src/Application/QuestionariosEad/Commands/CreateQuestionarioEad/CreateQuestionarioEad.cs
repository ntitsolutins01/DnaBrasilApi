using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.QuestionarioEadsEad.Commands.CreateQuestionarioEad;

public record CreateQuestionarioEadCommand : IRequest<int>
{
    public required List<string>? Urls { get; init; }
    public required string Pergunta { get; init; }
    public required int Quadrante { get; init; }
    public required int Questao { get; init; }
}

public class CreateQuestionarioEadCommandHandler : IRequestHandler<CreateQuestionarioEadCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateQuestionarioEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateQuestionarioEadCommand request, CancellationToken cancellationToken)
    {
        var entity = new QuestionarioEad
        {
            Pergunta = request.Pergunta,
            Quadrante = request.Quadrante,
            Questao = request.Questao
        };

        _context.QuestionariosEad.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
