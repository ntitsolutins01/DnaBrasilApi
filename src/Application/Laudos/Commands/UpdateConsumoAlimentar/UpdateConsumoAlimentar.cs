
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateConsumoAlimentar;

public record UpdateConsumoAlimentarCommand : IRequest <bool>
{
    public int Id { get; init; }
    public required string Resposta { get; init; }
    public Profissional? Profissional { get; init; }
    public Questionario? Questionario { get; init; }
    
}

public class UpdateConsumoAlimentarCommandHandler : IRequestHandler<UpdateConsumoAlimentarCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateConsumoAlimentarCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateConsumoAlimentarCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ConsumoAlimentares
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Resposta = request.Resposta;
        entity.Profissional = request.Profissional;
        entity.Questionario = request.Questionario;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}

