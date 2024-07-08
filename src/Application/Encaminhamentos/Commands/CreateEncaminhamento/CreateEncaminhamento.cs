using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Encaminhamentos.Commands.CreateEncaminhamento;
public record CreateEncaminhamentoCommand : IRequest<int>
{
    public required int TipoLaudoId { get; init; }
    public required string Nome { get; init; }
    public required string Parametro { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateEncaminhamentoCommandHandler : IRequestHandler<CreateEncaminhamentoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEncaminhamentoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEncaminhamentoCommand request, CancellationToken cancellationToken)
    {
        var tipolaudo = await _context.TipoLaudos
            .FindAsync([request.TipoLaudoId], cancellationToken);

        Guard.Against.NotFound(request.TipoLaudoId, tipolaudo);

        var entity = new Encaminhamento
        {
            TipoLaudo = tipolaudo,
            Nome = request.Nome,
            Parametro = request.Parametro,
            Descricao = request.Descricao,
            Status = request.Status
        };

        _context.Encaminhamentos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
