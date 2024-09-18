using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.RespostasEad.Commands.UpdateRespostaEad;

public record UpdateRespostaEadCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string RespostaQuestionarioEad { get; init; }
    public required decimal ValorPesoRespostaEad { get; set; }

}

public class UpdateRespostaEadCommandHandler : IRequestHandler<UpdateRespostaEadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateRespostaEadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateRespostaEadCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.RespostasEad
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.RespostaQuestionarioEad = request.RespostaQuestionarioEad;
        entity.ValorPesoRespostaEad = request.ValorPesoRespostaEad;
        

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
