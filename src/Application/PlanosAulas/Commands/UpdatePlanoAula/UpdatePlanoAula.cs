using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.PlanosAulas.Commands.UpdatePlanoAula;

public record UpdatePlanoAulaCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? Nome { get; set; }
    public string? TipoEscolaridade { get; set; }
    public string? Modalidade { get; set; }
    public string? Url { get; set; }
}

public class UpdatePlanoAulaCommandHandler : IRequestHandler<UpdatePlanoAulaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdatePlanoAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdatePlanoAulaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.PlanosAulas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Modalidade = request.Modalidade;
        entity.TipoEscolaridade = request.TipoEscolaridade;
        entity.Url = request.Url;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
