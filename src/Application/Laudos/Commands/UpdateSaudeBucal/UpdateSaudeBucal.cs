using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.UpdateSaudeBucal;

public record UpdateSaudeBucalCommand : IRequest <bool>
{
    public int Id { get; init; }
    public required string Resposta { get; init; }
}

public class UpdateSaudeBucalCommandHandler : IRequestHandler<UpdateSaudeBucalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateSaudeBucalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateSaudeBucalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.SaudeBucais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Respostas = request.Resposta;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
