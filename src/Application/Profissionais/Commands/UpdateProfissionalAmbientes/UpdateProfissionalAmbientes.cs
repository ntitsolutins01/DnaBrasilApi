using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Commands.UpdateProfissionalAmbientes;
public record UpdateProfissionalAmbientesCommand : IRequest
{
    public int Id { get; init; }
    public List<Ambiente>? Ambientes { get; init; }
}

public class UpdateProfissionalAmbientesCommandHandler : IRequestHandler<UpdateProfissionalAmbientesCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProfissionalAmbientesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProfissionalAmbientesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Ambientes = request.Ambientes;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
