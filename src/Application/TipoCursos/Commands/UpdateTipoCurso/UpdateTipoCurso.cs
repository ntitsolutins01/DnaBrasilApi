using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.TipoCursos.Commands.UpdateTipoCurso;

public record UpdateTipoCursoCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; init; }
}

public class UpdateTipoCursoCommandHandler : IRequestHandler<UpdateTipoCursoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateTipoCursoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateTipoCursoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TipoCursos
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome;
        entity.Status = request.Status;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
