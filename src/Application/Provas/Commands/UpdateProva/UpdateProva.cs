using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Provas.Commands.UpdateProva;

public record UpdateProvaCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int AulaId { get; init; }
    public required string Titulo { get; init; }
    public bool ProvaRequisito { get; init; } 
    public required int Peso { get; init; }
    public required int MediaAprovacao { get; init; }
    public required string LiberacaoProva { get; init; }
    public required string DataLiberacao { get; init; }
    public required string DuracaoProva { get; init; }
    public string? DataEncerramento { get; init; }
    public bool PermitirTentativas { get; init; } 
    public int Tentativas { get; init; }
    public bool LiberarTentativa { get; init; } 
    public bool Status { get; init; }
}

public class UpdateProvaCommandHandler : IRequestHandler<UpdateProvaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateProvaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateProvaCommand request, CancellationToken cancellationToken)
    {
        var aula = await _context.Aulas
            .FindAsync([request.AulaId], cancellationToken);

        Guard.Against.NotFound(request.AulaId, aula);
        
        var entity = await _context.Provas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Aula = aula;
        entity.Titulo = request.Titulo;
        entity.ProvaRequisito = request.ProvaRequisito;
        entity.Peso = request.Peso;
        entity.MediaAprovacao = request.MediaAprovacao;
        entity.LiberacaoProva = request.LiberacaoProva;
        entity.DataLiberacao = DateTime.ParseExact(request.DataLiberacao, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
        entity.DuracaoProva = TimeSpan.Parse(request.DuracaoProva);
        entity.DataEncerramento = DateTime.ParseExact(request.DataEncerramento!, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
        entity.PermitirTentativas = request.PermitirTentativas;
        entity.Tentativas = request.Tentativas;
        entity.LiberarTentativa = request.LiberarTentativa;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
