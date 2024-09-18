using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.QuestionariosEad.Commands.UpdateQuestionarioEad;

public record UpdateQuestionarioEadCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Pergunta { get; init; }
    public required int Quadrante { get; init; }
    public required int Questao { get; init; }

}

public class UpdateQuestionarioEadCommandHandler : IRequestHandler<UpdateQuestionarioEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuestionarioEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateQuestionarioEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QuestionariosEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Pergunta = request.Pergunta;
        entity.Quadrante = request.Quadrante;
        entity.Questao = request.Questao;
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
