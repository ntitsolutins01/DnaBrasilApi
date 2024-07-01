using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Provas.Commands.CreateProva;
public record CreateProvaCommand : IRequest<int>
{
    public required int AulaId { get; init; }
    public required string Titulo { get; init; }
    public bool ProvaRequisito { get; init; } = false;
    public required int Peso { get; init; }
    public required int MediaAprovacao { get; init; }
    public required string LiberacaoProva { get; init; }
    public required string DataLiberacao { get; init; }
    public required string DuracaoProva { get; init; }
    public string? DataEncerramento { get; init; }
    public bool PermitirTentativas { get; init; } = false;
    public int Tentativas { get; init; }
    public bool LiberarTentativa { get; init; } = false;
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
            Aula = aula,
            Titulo = request.Titulo,
            Peso = request.Peso,
            MediaAprovacao = request.MediaAprovacao,
            LiberacaoProva = request.LiberacaoProva,
            DataLiberacao = DateTime.ParseExact(request.DataLiberacao, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            DuracaoProva = TimeSpan.Parse(request.DuracaoProva),
            DataEncerramento = DateTime.ParseExact(request.DataEncerramento!, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            Tentativas = request.Tentativas

        };

        _context.Provas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
