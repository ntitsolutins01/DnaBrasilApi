using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Respostas.Commands.UpdateResposta;

public record UpdateRespostaCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string RespostaQuestionario { get; init; }
    public required int ValorPesoResposta { get; set; }

}

public class UpdateRespostaCommandHandler : IRequestHandler<UpdateRespostaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateRespostaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateRespostaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Respostas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.RespostaQuestionario = request.RespostaQuestionario;
        entity.ValorPesoResposta = request.ValorPesoResposta;
        

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
