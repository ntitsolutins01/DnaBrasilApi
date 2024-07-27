using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Encaminhamentos.Commands.UpdateEncaminhamento;

public record UpdateEncaminhamentoCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
    public required string Parametro { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
}

public class UpdateEncaminhamentoCommandHandler : IRequestHandler<UpdateEncaminhamentoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEncaminhamentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEncaminhamentoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Encaminhamentos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Parametro = request.Parametro;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
