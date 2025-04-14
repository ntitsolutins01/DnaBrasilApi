using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesFrequencias.Commands.UpdateControleFrequencia;

public record UpdateControleFrequenciaCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? Presenca { get; init; }
    public string? Justificativa { get; init; }
    public bool Status { get; init; } = true;
}

public class UpdateControleFrequenciaCommandHandler : IRequestHandler<UpdateControleFrequenciaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateControleFrequenciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateControleFrequenciaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesFrequencias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);


        entity.Presenca = request.Presenca;
        entity.Justificativa = request.Justificativa;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
