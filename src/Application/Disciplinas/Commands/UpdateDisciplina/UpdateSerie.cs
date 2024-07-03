using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Disciplinas.Commands.UpdateDisciplina;

public record UpdateDisciplinaCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
}

public class UpdateDisciplinaCommandHandler : IRequestHandler<UpdateDisciplinaCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateDisciplinaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateDisciplinaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Disciplinas
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
