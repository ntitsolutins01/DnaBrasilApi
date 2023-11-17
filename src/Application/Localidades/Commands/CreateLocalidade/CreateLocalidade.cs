using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Localidades.Commands.CreateLocalidade;
public record CreateLocalidadeCommand : IRequest<int>
{
    public required string? Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; set; } = true;
    public int MunicipioId { get; set; }
}

public class CreateLocalidadeCommandHandler : IRequestHandler<CreateLocalidadeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateLocalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLocalidadeCommand request, CancellationToken cancellationToken)
    {
        var municipio = _context.Municipios.Where(x=>x.Id == request.MunicipioId).FirstOrDefault();
        var entity = new Localidade
        {
            Nome = request.Nome,
            Descricao = request.Descricao,
            Status = request.Status,
            Municipio = municipio   
        };

        _context.Localidades.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
