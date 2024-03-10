using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Commands.CreateLaudo;

public record CreateLaudoCommand : IRequest<int>
{
    public int? AlunoId { get; init; }
    public int? SaudeId { get; init; }
}

public class CreateLaudoCommandHandler : IRequestHandler<CreateLaudoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateLaudoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateLaudoCommand request, CancellationToken cancellationToken)
    {
        var aluno = await _context.Alunos
            .FindAsync([request.AlunoId!], cancellationToken);

        Guard.Against.NotFound((int)request.AlunoId!, aluno);

        Saude? saude = null;

        if (request.SaudeId != null)
        {
            saude = await _context.Saudes
                .FindAsync([request.SaudeId!], cancellationToken);

            Guard.Against.NotFound((int)request.SaudeId!, saude);
        }

        var entity = new Laudo()
        {
            Aluno = aluno,
            Saude = saude
        };

        _context.Laudos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
