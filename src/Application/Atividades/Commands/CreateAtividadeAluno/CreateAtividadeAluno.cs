using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Atividades.Commands.CreateAtividadeAluno;
public record CreateAtividadeAlunoCommand : IRequest<int>
{
    public required int AtividadeId { get; init; }
    public required string AlunosIds { get; init; }
}

public class CreateAtividadeAlunoCommandHandler : IRequestHandler<CreateAtividadeAlunoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAtividadeAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAtividadeAlunoCommand request, CancellationToken cancellationToken)
    {
        var estrutura = await _context.Atividades
            .FindAsync([request.AtividadeId], cancellationToken);

        Guard.Against.NotFound(request.AtividadeId, estrutura);

        int[] arrAluIds = request.AlunosIds.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

        foreach (int id in arrAluIds)
        {
            _context.AtividadeAlunos.Add(new AtividadeAluno() { AlunoId = id, AtividadeId = request.AtividadeId });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return request.AtividadeId;
    }
}
