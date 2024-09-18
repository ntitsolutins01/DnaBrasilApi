using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.RespostasEad.Commands.UpdateRespostaEad;

public record UpdateRespostaEadCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string TipoResposta { get; init; }
    public string? TipoAlternativa { get; init; }
    public required string Resposta { get; init; }
    public required decimal ValorPesoResposta { get; init; }

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

        //todo: Lutercio implementar 

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
