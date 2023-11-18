using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAluno;
public record DeleteAlunoCommand(int Id) : IRequest;

public class DeleteAlunoCommandHandler : IRequestHandler<DeleteAlunoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Alunos.Remove(entity);

        //entity.AddDomainEvent(new AlunoDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
