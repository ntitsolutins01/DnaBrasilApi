using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoFoto;

public record UpdateAlunoFotoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? NomeFoto { get; init; }
    public byte[]? ByteImage { get; init; }
}

public class UpdateAlunoFotoCommandHandler : IRequestHandler<UpdateAlunoFotoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoFotoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateAlunoFotoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.ByteImage = request.ByteImage;
        entity.NomeFoto = request.NomeFoto;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
