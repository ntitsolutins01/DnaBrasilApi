using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TextosLaudos.Commands.UpdateTextoLaudo;

public record UpdateTextoLaudoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public int? TipoLaudoId { get; init; }
    public int? Idade { get; set; }
    public string? Sexo { get; set; }
    public string? Classificacao { get; init; }
    public decimal PontoInicial { get; init; }
    public decimal PontoFinal { get; init; }
    public string? Aviso { get; init; }
    public string? Texto { get; init; }
    public bool Status { get; init; }
}

public class UpdateTextoLaudoCommandHandler : IRequestHandler<UpdateTextoLaudoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTextoLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateTextoLaudoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TextosLaudos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Idade = request.Idade;
        entity.Sexo = request.Sexo; 
        entity.Classificacao = request.Classificacao;
        entity.PontoInicial = request.PontoInicial;
        entity.PontoFinal = request.PontoFinal;
        entity.Aviso = request.Aviso;
        entity.Texto = request.Texto;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
