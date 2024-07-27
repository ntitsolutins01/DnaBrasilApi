using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoDeficiencias;

public record DeleteAlunoDeficienciasCommand(int Id) : IRequest;

public class DeleteAlunoDeficienciasCommandHandler : IRequestHandler<DeleteAlunoDeficienciasCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoDeficienciasCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAlunoDeficienciasCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Alunos.Remove(entity);

        //entity.AddDomainEvent(new AlunoDeficienciasDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
