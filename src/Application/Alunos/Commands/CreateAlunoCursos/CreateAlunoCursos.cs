using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateAlunoCursos;
public record CreateAlunoCursoCommand : IRequest<int>
{
    public required int AlunoId { get; init; }
    public required string CursosId { get; init; }
}

public class CreateAlunoCursoCommandHandler : IRequestHandler<CreateAlunoCursoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoCursoCommand request, CancellationToken cancellationToken)
    {
        var estrutura = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, estrutura);

        int[] arrAluIds = request.CursosId.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

        foreach (int id in arrAluIds)
        {
            _context.AlunoCursosCertificados.Add(new AlunoCursoCertificado() { CursoId = id, AlunoId = request.AlunoId });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return request.AlunoId;
    }
}
