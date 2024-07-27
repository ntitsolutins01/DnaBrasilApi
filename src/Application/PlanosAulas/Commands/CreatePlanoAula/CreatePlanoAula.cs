using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.PlanosAulas.Commands.CreatePlanoAula;
public record CreatePlanoAulaCommand : IRequest<int>
{
    public string? Nome { get; set; }
    public string? Url { get; set; }
    public string? TipoEscolaridade { get; set; }
    public string? Modalidade { get; set; }
    public string? NomeArquivo { get; set; }
}

public class CreatePlanoAulaCommandHandler : IRequestHandler<CreatePlanoAulaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePlanoAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePlanoAulaCommand request, CancellationToken cancellationToken)
    {
        var entity = new PlanoAula
        {
            Nome = request.Nome,
            Modalidade = request.Modalidade,
            TipoEscolaridade = request.TipoEscolaridade,
            Url = request.Url,
            NomeArquivo = request.NomeArquivo
        };

        _context.PlanosAulas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
