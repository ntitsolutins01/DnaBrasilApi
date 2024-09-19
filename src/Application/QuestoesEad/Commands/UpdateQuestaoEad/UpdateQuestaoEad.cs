using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.QuestoesEad.Commands.UpdateQuestaoEad;

public record UpdateQuestaoEadCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Pergunta { get; init; }
    public required string Referencia { get; init; }
    public required int Questao { get; init; }

}

public class UpdateQuestaoEadCommandHandler : IRequestHandler<UpdateQuestaoEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuestaoEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateQuestaoEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QuestoesEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Enunciado = request.Pergunta;
        entity.Referencia = request.Referencia;
        entity.Questao = request.Questao;
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
