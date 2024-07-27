using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Municipios.Commands.DeleteMunicipio;
public record DeleteMunicipioCommand(int Id) : IRequest;

public class DeleteMunicipioCommandHandler : IRequestHandler<DeleteMunicipioCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteMunicipioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteMunicipioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Municipios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Municipios.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
