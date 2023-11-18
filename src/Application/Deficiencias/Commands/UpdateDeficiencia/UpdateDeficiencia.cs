using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Deficiencias.Commands.UpdateDeficiencia;

public record UpdateDeficienciaCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; init; }
}

public class UpdateDeficienciaCommandHandler : IRequestHandler<UpdateDeficienciaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateDeficienciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateDeficienciaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Deficiencias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
