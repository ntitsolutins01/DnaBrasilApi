using DnaBrasil.Application.Alunos.Commands.CreateVoucher;
using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Commands.CreateVoucher;

public record CreateVoucherCommand : IRequest<int>
{
    public int Id { get; set; }
    public Local? Local { get; set; }
    public string? Descricao { get; set; }
    public string? Turma { get; set; }
    public string? Serie { get; set; }
}

public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateVoucherCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
    {

        var entity = new Voucher()
        {
            Local = request.Local,
            Descricao = request.Descricao,
            Turma = request.Turma,
            Serie = request.Serie,
            DomainEvents = {  }
        };

        _context.Vouchers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
