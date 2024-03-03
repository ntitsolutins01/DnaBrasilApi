using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Questionarios.Commands.CreateQuestionario;

public record CreateQuestionarioCommand : IRequest<int>
{
    public required string Pergunta { get; init; }
    public required int TipoLaudoId { get; init; }
    public required int Quadrante { get; init; }
    public required int Questao { get; init; }
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
        var tipoLaudo = await _context.TipoLaudos
            .FindAsync(new object[] { request.TipoLaudoId }, cancellationToken);

        Guard.Against.NotFound(request.TipoLaudoId, tipoLaudo);

        var entity = new Questionario
        {
            Pergunta = request.Pergunta,
            TipoLaudo = tipoLaudo!,
            Quadrante = request.Quadrante,
            Questao = request.Questao
        };

        _context.Questionarios.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
