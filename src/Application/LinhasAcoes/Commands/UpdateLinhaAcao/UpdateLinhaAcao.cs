using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.LinhasAcoes.Commands.UpdateLinhaAcao;

public record UpdateLinhaAcaoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; init; }

}

public class UpdateLinhaAcaoCommandHandler : IRequestHandler<UpdateLinhaAcaoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateLinhaAcaoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateLinhaAcaoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.LinhasAcoes
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
