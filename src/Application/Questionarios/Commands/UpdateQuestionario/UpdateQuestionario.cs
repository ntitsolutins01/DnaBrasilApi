using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Questionarios.Commands.UpdateQuestionario;

public record UpdateQuestionarioCommand : IRequest<bool>
{
    public int Id { get; init; }
    public required string Pergunta { get; init; }
    public required int TipoLaudoId { get; init; }
   
}

public class UpdateQuestionarioCommandHandler : IRequestHandler<UpdateQuestionarioCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuestionarioCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateQuestionarioCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questionarios
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Pergunta = request.Pergunta;
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
