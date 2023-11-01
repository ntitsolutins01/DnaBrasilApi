using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Questionarios.Commands.CreateQuestionário;

public record CreateQuestionarioCommand : IRequest<int>
{
    public required string Pergunta { get; init; }
    public required TipoLaudo Tipo { get; init; }
}

public class CreateQuestionarioCommandHandler : IRequestHandler<CreateQuestionarioCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateQuestionarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateQuestionarioCommand request, CancellationToken cancellationToken)
    {
        var entity = new Questionario
        {
            Pergunta = request.Pergunta,
            Tipo = request.Tipo
        };

        _context.Questionarios.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
