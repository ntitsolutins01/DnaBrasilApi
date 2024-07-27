using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoAmbientes;

public record UpdateAlunoModalidadesCommand : IRequest
{
    public int AlunoId { get; init; }
    public List<Modalidade>? Modalidades { get; init; }
}

public class UpdateAlunoModalidadesCommandHandler : IRequestHandler<UpdateAlunoModalidadesCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoModalidadesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateAlunoModalidadesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.AlunoId }, cancellationToken);

        Guard.Against.NotFound(request.AlunoId, entity);

        entity.Modalidades = request.Modalidades;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
