using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.AlunosCertificados.Commands.UpdateAlunoCertificado;

public record UpdateAlunoCertificadoCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int Progesso { get; init; }
}

public class UpdateAlunoCertificadoCommandHandler : IRequestHandler<UpdateAlunoCertificadoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoCertificadoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateAlunoCertificadoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.AlunosCertificados
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
