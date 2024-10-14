using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Questionarios.Commands.UpdateQuestionario;

public record UpdateQuestionarioCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Pergunta { get; init; }
    public required int TipoLaudoId { get; init; }
    public required int Quadrante { get; init; }
    public required int Questao { get; init; }

}

public class UpdateQuestionarioCommandHandler : IRequestHandler<UpdateQuestionarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuestionarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateQuestionarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questionarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Pergunta = request.Pergunta;
        entity.Quadrante = request.Quadrante;
        entity.Questao = request.Questao;
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
