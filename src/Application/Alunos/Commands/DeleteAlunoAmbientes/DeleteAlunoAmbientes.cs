using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoAmbientes;

public record DeleteAlunoAmbientesCommand(int Id) : IRequest;

public class DeleteAlunoAmbientesCommandHandler : IRequestHandler<DeleteAlunoAmbientesCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAlunoAmbientesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAlunoAmbientesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Alunos.Remove(entity);

        //entity.AddDomainEvent(new AlunoAmbientesDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
