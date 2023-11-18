using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Localidades.Commands.UpdateLocalidade;

public record UpdateLocalidadeCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string? Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; set; } = true;
    public int MunicipioId { get; set; }
}

public class UpdateLocalidadeCommandHandler : IRequestHandler<UpdateLocalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateLocalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateLocalidadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Localidades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var municipio = _context.Municipios.Where(x => x.Id == request.MunicipioId).FirstOrDefault();

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;
        entity.Municipio = municipio;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
