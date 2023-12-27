using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Contratos.Commands.UpdateContrato;

public record UpdateContratoCommand : IRequest <bool>
{
    public int Id { get; init; }
    public  string? Nome { get; set; }
    public  string? Descricao { get; set; }
    public  string? DtIni { get; set; }
    public  string? DtFim { get; set; }
    public string? Anexo { get; set; }
    public bool Status { get; set; } = true;
}

public class UpdateContratoCommandHandler : IRequestHandler<UpdateContratoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateContratoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateContratoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contratos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome!;
        entity.Descricao = request.Descricao;
        entity.DtFim = Convert.ToDateTime(request.DtFim);
        entity.DtIni = Convert.ToDateTime(request.DtIni);
        entity.Anexo = request.Anexo;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
