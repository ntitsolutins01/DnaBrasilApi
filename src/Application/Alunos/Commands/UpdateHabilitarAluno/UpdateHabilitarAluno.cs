using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Common.Security;
using DnaBrasilApi.Domain.Constants;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateHabilitarAluno;

[Authorize(Roles = Roles.Administrador)]
[Authorize(Policy = Policies.Habilitar)]
public record UpdateHabilitarAlunoCommand : IRequest<bool>
{
    public required int AlunoId { get; init; }
    public required string AspNetUserId { get; init; }
}

public class UpdateHabilitarAlunoCommandHandler : IRequestHandler<UpdateHabilitarAlunoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateHabilitarAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateHabilitarAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync([request.AlunoId], cancellationToken);

        Guard.Against.NotFound(request.AlunoId, entity);

        entity.Habilitado = true;
        entity.Status = true;
        entity.AspNetUserId = request.AspNetUserId;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
