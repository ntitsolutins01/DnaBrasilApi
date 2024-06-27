using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesAcessosAulas.Commands.CreateControleAcessoAula;
public record CreateControleAcessoAulaCommand : IRequest<int>
{
    public required int AulaId { get; init; }
    public bool IdentificacaoAluno { get; init; } = false;
    public bool AulaRequisito { get; init; } = false;
    public bool PermanenciaAula { get; init; } = false;
    public required string TempoPermanecia { get; init; }
    public required string LiberacaoAula { get; init; }
    public required string DataLiberacao { get; init; }
    public required string DataEncerramento { get; init; }
    public bool Status { get; init; } = true;
}

public class CreateControleAcessoAulaCommandHandler : IRequestHandler<CreateControleAcessoAulaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateControleAcessoAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateControleAcessoAulaCommand request, CancellationToken cancellationToken)
    {
        var aula = await _context.Aulas
            .FindAsync([request.AulaId], cancellationToken);

        Guard.Against.NotFound(request.AulaId, aula);


        var entity = new ControleAcessoAula
        {
            Aula = aula,
            LiberacaoAula = request.LiberacaoAula,
            DataLiberacao = DateTime.ParseExact(request.DataLiberacao, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            TempoPermanecia = TimeSpan.Parse(request.TempoPermanecia),
            DataEncerramento = DateTime.ParseExact(request.DataEncerramento!, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),

        };

        _context.ControlesAcessosAulas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
