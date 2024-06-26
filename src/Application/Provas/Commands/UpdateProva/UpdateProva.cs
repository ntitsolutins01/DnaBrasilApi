using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Provas.Commands.UpdateProva;

public record UpdateProvaCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Titulo { get; set; }
    public required bool ProvaRequisito { get; set; }
    public required int Peso { get; set; }
    public required int MediaAprovacao { get; set; }
    public required string LiberacaoProva { get; set; }
    public required string DataLiberacao { get; set; }
    public required string DataEncerramento { get; set; }
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
        var entity = await _context.Provas
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);


        entity.LiberacaoProva = request.LiberacaoProva;
        entity.Peso = request.Peso;
        entity.MediaAprovacao = request.MediaAprovacao;
        entity.Titulo = request.Titulo;
        entity.ProvaRequisito = request.ProvaRequisito;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
