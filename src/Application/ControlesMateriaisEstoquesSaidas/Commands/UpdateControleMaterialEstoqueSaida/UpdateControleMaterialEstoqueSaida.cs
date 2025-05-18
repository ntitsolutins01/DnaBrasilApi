using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Commands.UpdateControleMaterialEstoqueSaida;

public record UpdateControleMaterialEstoqueSaidaCommand : IRequest<bool>
{
    public required int Id { get; set; }
    public required int ProfissionalId { get; set; }
}

public class UpdateControleMaterialEstoqueSaidaCommandHandler : IRequestHandler<UpdateControleMaterialEstoqueSaidaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateControleMaterialEstoqueSaidaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateControleMaterialEstoqueSaidaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ControlesMateriaisEstoquesSaidas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var profissional = await _context.Usuarios
            .FindAsync([request.ProfissionalId], cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        entity.Usuario = profissional;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
