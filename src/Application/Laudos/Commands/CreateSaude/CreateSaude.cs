using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateSaude;

public record CreateSaudeCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required int ProfissionalId { get; init; }
    public required  decimal EnvergaduraSaude { get; init; }
    public required  decimal MassaCorporalSaude { get; init; }
    public required  decimal AlturaSaude { get; init; }
    public required  string StatusSaude { get; init; }
}

public class CreateSaudeCommandHandler : IRequestHandler<CreateSaudeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSaudeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSaudeCommand request, CancellationToken cancellationToken)
    {

        var aluno = await _context.Alunos.FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, aluno);

        var profissional = await _context.Profissionais.FindAsync([request.ProfissionalId], cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        var entity = new Saude
        {
            Aluno = aluno,
            Profissional = profissional,
            Altura = request.AlturaSaude,
            Massa = request.MassaCorporalSaude,
            Envergadura = request.EnvergaduraSaude,
            StatusSaude = request.StatusSaude
        };

        _context.Saudes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
