using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.UpdateControleFrequenciaEscolar;

public record UpdateControleFrequenciaEscolarCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public required string Controle { get; init; }
}

public class UpdateControleFrequenciaEscolarCommandHandler : IRequestHandler<UpdateControleFrequenciaEscolarCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateControleFrequenciaEscolarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateControleFrequenciaEscolarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesFrequenciasEscolares
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound<ControleFrequenciaEscolar>(request.Id.ToString(), entity);

        entity.Controle = request.Controle;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;
    }
}
