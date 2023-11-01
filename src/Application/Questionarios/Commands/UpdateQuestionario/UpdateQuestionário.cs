using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Questionarios.Commands.UpdateQuestionario;

public record UpdateQuestionarioCommand : IRequest
{
    public int Id { get; init; }
    public required string Pergunta { get; init; }
    public required TipoLaudo Tipo { get; init; }
}

public class UpdateQuestionarioCommandHandler : IRequestHandler<UpdateQuestionarioCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuestionarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateQuestionarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questionarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Pergunta = request.Pergunta;
        entity.Tipo = request.Tipo;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
