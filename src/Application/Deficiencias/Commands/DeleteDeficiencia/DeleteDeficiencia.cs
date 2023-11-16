using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Deficiencias.Commands.DeleteDeficiencia;

public record DeleteDeficienciaCommand(int Id) : IRequest<bool>;

public class DeleteDeficienciaCommandHandler : IRequestHandler<DeleteDeficienciaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteDeficienciaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteDeficienciaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Deficiencias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Deficiencias.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
