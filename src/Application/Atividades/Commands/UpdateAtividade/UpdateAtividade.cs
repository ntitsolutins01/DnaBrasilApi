using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Atividades.Commands.UpdateAtividade;

public record UpdateAtividadeCommand : IRequest <bool>
{
    public required int Id { get; init; }
    public required int EstruturaId { get; set; }
    public required int LinhaAcaoId { get; set; }
    public required int AtividadeId { get; set; }
    public required int ModalidadeId { get; set; }
    public string? Turma { get; set; }
    public DateTime? HrIni { get; set; }
    public DateTime? HrFim { get; set; }
    public required int ProfissionalId { get; set; }
    public required int LocalidadeId { get; set; }
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
        entity.HrIni = request.HrIni;
        entity.HrFim = request.HrFim;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
