using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Commands.UpdateAtividade;

public record UpdateAtividadeCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public string? Turma { get; set; }
    public TimeSpan? HrInicial { get; set; }
    public TimeSpan? HrFinal { get; set; }
}

public class UpdateAtividadeCommandHandler : IRequestHandler<UpdateAtividadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAtividadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateAtividadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Atividades
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);
        
        entity.Turma = request.Turma;
        entity.HrInicial = request.HrInicial;
        entity.HrFinal = request.HrFinal;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
