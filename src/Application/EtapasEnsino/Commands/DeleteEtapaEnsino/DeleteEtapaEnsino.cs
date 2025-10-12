using DnaBrasilApi.Application.Common.Exceptions;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.EtapasEnsino.Commands.DeleteEtapaEnsino;

public record DeleteEtapaEnsinoCommand(int Id) : IRequest<bool>;

public class DeleteEtapaEnsinoCommandHandler : IRequestHandler<DeleteEtapaEnsinoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEtapaEnsinoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEtapaEnsinoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.EtapasEnsino
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.EtapasEnsino.Remove(entity);

        var hasRelatedStudents = await _context.Series
        .Where(s => s.EtapaEnsino.Id == request.Id)
        .AnyAsync(s => _context.Alunos.Any(a => a.Serie != null && a.Serie.Id == s.Id), cancellationToken);

        if (hasRelatedStudents)
        {
            Guard.Against.PossuiAlunosEtapasEnsino(hasRelatedStudents);
        }

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }
}


