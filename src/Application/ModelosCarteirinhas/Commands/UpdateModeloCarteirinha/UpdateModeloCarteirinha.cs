using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Commands.UpdateModeloCarteirinha;

public record UpdateModeloCarteirinhaCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? NomeImagem { get; init; }
    public string? UrlImagem { get; init; }

}

public class UpdateModeloCarteirinhaCommandHandler : IRequestHandler<UpdateModeloCarteirinhaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateModeloCarteirinhaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateModeloCarteirinhaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ModelosCarteirinhas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.NomeImagem = request.NomeImagem;
        entity.UrlImagem = request.UrlImagem;
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
