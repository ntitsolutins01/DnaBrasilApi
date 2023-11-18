using DnaBrasilApi.Application.Alunos.Commands.CreateVoucher;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateVoucher;

public record CreateVoucherCommand : IRequest<int>
{
    public int Id { get; set; }
    public Localidade? Local { get; set; }
    public string? Descricao { get; set; }
    public string? Turma { get; set; }
    public string? Serie { get; set; }
    public required Aluno Aluno { get; set; }
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
            Aluno = request.Aluno
        };

        _context.Vouchers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
