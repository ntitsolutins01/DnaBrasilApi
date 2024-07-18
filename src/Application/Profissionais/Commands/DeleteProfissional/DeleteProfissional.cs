using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.Profissionais.Commands.DeleteProfissional;
public record DeleteProfissionalCommand(int Id) : IRequest<bool>;

public class DeleteProfissionalCommandHandler : IRequestHandler<DeleteProfissionalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteProfissionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProfissionalCommand request, CancellationToken cancellationToken)
    {
        int result;

        var entity = await _context.Profissionais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var possuiAlunos = _context.Alunos.Any(x => x.Profissional != null && x.Profissional.Id == request.Id);

        Guard.Against.Null(possuiAlunos, nameof(possuiAlunos), "Engine cannot be null!");


        _context.Profissionais.Remove(entity);

        result = await _context.SaveChangesAsync(cancellationToken);


        return result == 1;
    }

}
