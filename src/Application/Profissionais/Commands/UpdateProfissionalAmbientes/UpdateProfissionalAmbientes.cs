using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Commands.UpdateProfissionalAmbientes;
public record UpdateProfissionalModalidadesCommand : IRequest
{
    public int Id { get; init; }
    public List<Modalidade>? Modalidades { get; init; }
}

public class UpdateProfissionalModalidadesCommandHandler : IRequestHandler<UpdateProfissionalModalidadesCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProfissionalModalidadesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProfissionalModalidadesCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Modalidades = request.Modalidades;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
