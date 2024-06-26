using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Provas.Commands.CreateProva;
public record CreateProvaCommand : IRequest<int>
{
    public required int AulaId { get; set; }
    public required string Titulo { get; set; }
    public required bool ProvaRequisito { get; set; }
    public required int Peso { get; set; }
    public required int MediaAprovacao { get; set; }
    public required string LiberacaoProva { get; set; }
    public required DateTime DataLiberacao { get; set; }
    public required DateTime DataEncerramento { get; set; }
    public bool Status { get; init; } = true;
}

public class CreateProvaCommandHandler : IRequestHandler<CreateProvaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProvaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProvaCommand request, CancellationToken cancellationToken)
    {
        var aula = await _context.Aulas
            .FindAsync([request.AulaId], cancellationToken);

        Guard.Against.NotFound(request.AulaId, aula);


        var entity = new Prova
        {
            LiberacaoProva = request.LiberacaoProva,
            Peso = request.Peso,
            Aula = aula,
            MediaAprovacao = request.MediaAprovacao,
            Titulo = request.Titulo,
            DataLiberacao = request.DataLiberacao,
            DataEncerramento = request.DataEncerramento,
            ProvaRequisito = request.ProvaRequisito,
            Status = request.Status
        };

        _context.Provas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
