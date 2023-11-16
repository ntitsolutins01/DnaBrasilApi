using DnaBrasil.Application.Alunos.Commands.CreateVoucher;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Commands.UpdateVoucher;

public record UpdateVoucherCommand : IRequest <bool>
{
    public int Id { get; set; }
    public Localidade? Local { get; set; }
    public string? Descricao { get; set; }
    public string? Turma { get; set; }
    public string? Serie { get; set; }
}

public class UpdateVoucherCommandHandler : IRequestHandler<UpdateVoucherCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateVoucherCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task <bool> Handle(UpdateVoucherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Vouchers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Local = request.Local;
        entity.Descricao = request.Descricao;
        entity.Turma = request.Turma;
        entity.Serie = request.Serie;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
