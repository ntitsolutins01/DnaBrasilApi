using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.RespostasEad.Commands.CreateRespostaEad;

public record CreateRespostaEadCommand : IRequest<int>
{
    public required string RespostaQuestionarioEad { get; init; }
    public required int QuestionarioEadId { get; init; }
    public required decimal ValorPesoRespostaEad { get; init; }
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
        var questionarioEad = await _context.QuestionariosEad
            .FindAsync(new object[] { request.QuestionarioEadId }, cancellationToken);

        Guard.Against.NotFound(request.QuestionarioEadId, questionarioEad);

        var entity = new RespostaEad
        {
            RespostaQuestionarioEad = request.RespostaQuestionarioEad,
            QuestionarioEad = questionarioEad!,
            ValorPesoRespostaEad = request.ValorPesoRespostaEad
        };

        _context.RespostasEad.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
