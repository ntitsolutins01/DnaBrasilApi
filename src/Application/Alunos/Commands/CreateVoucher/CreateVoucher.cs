using DnaBrasil.Application.Alunos.Commands.CreateVoucher;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Commands.CreateVoucher;

public record CreateVoucherCommand : IRequest
{
    public int Id { get; set; }
    public Local? Local { get; set; }
    public string? Descricao { get; set; }
    public string? Turma { get; set; }
    public string? Serie { get; set; }
}

public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateVoucherCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Vouchers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Local = request.Local;
        entity.Descricao = request.Descricao;
        entity.Turma = request.Turma;
        entity.Serie = request.Serie;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
