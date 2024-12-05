using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateQrCode;

public record UpdateQrCodeCommand : IRequest<bool>
{
    public int Id { get; init; }
    public byte[]? QrCode { get; set; }
}

public class UpdateQrCodeCommandHandler : IRequestHandler<UpdateQrCodeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateQrCodeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateQrCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.ByteImage = request.QrCode;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
