using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAluno;
public record DeleteAlunoCommand(int Id) : IRequest<bool>;

public class DeleteAlunoCommandHandler : IRequestHandler<DeleteAlunoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var possuiLaudos = _context.Laudos.Any(x => x.Aluno.Id == request.Id);

        Guard.Against.PossuiLaudos(possuiLaudos);
        
        _context.Alunos.Remove(entity);

        var responsavel = await _context.Responsaveis
            .Where(x => entity.Responsavel != null && x.Id == entity.Responsavel.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (responsavel != null && responsavel.Alunos != null && responsavel.Alunos.Count == 0)
        {
            _context.Responsaveis.Remove(responsavel);
        }

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }
}
