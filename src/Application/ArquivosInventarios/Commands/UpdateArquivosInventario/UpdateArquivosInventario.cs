using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ArquivosInventarios.Commands.UpdateArquivosInventario;

public record UpdateArquivosInventarioCommand : IRequest<bool>
{
    public required int Id { get; init; }
    public string? NomeArquivo { get; init; }
}

public class UpdateArquivosInventarioCommandHandler : IRequestHandler<UpdateArquivosInventarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateArquivosInventarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateArquivosInventarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ArquivosInventarios
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.NomeArquivo = request.NomeArquivo;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
