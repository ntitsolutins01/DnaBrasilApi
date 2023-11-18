using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoAmbientes;

public record UpdateAlunoAmbientesCommand : IRequest
{
    public int AlunoId { get; init; }
    public List<Ambiente>? Ambientes { get; init; }
}

public class UpdateAlunoAmbientesCommandHandler : IRequestHandler<UpdateAlunoAmbientesCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoAmbientesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateAlunoAmbientesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound(request.AlunoId, entity);

        entity.Ambientes = request.Ambientes;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
