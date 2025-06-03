using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ModelosCarteirinhas.Commands.CreateModeloCarteirinha;

public record CreateModeloCarteirinhaCommand : IRequest<int>
{
    public required int FomentoId { get; init; }
    public string? NomeImagemFrente { get; init; }
    public string? UrlImagemFrente { get; init; }
    public string? NomeImagemVerso { get; init; }
    public string? UrlImagemVerso { get; init; }
}

public class CreateModeloCarteirinhaCommandHandler : IRequestHandler<CreateModeloCarteirinhaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateModeloCarteirinhaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateModeloCarteirinhaCommand request, CancellationToken cancellationToken)
    {
        var fomento = await _context.Fomentos
            .FindAsync(new object[] { request.FomentoId }, cancellationToken);

        Guard.Against.NotFound(request.FomentoId, fomento);

        var entity = new ModeloCarteirinha
        {
            Fomento = fomento,
            NomeImagemFrente = request.NomeImagemFrente,
            UrlImagemFrente = request.UrlImagemFrente,
            NomeImagemVerso = request.NomeImagemVerso,
            UrlImagemVerso = request.UrlImagemVerso
        };

        _context.ModelosCarteirinhas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
