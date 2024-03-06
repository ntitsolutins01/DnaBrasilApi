using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TextosLaudos.Commands.CreateTextoLaudo;

public record CreateTextoLaudoCommand : IRequest<int>
{
    public int? TipoLaudoId{ get; init; }
    public string? Classificacao{ get; init; }
    public decimal PontoInicial{ get; init; }
    public decimal PontoFinal { get; init; }
    public string? Aviso { get; init; }
    public string? Texto { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateTextoLaudoCommandHandler : IRequestHandler<CreateTextoLaudoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTextoLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTextoLaudoCommand request, CancellationToken cancellationToken)
    {
        var tipoLaudo = await _context.Profissionais
            .FindAsync([request.TipoLaudoId], cancellationToken);

        Guard.Against.NotFound((int)request.TipoLaudoId!, tipoLaudo);

        var entity = new TextoLaudo
        {
            Classificacao = request.Classificacao,
            PontoInicial = request.PontoInicial,
            PontoFinal = request.PontoFinal,
            Aviso = request.Aviso,
            Texto = request.Texto,
            Status = request.Status
        };

        _context.TextosLaudos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
