using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateVoucher;
public class CreateVoucherCommandValidator : AbstractValidator<CreateVoucherCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateVoucherCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Descricao)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Turma)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(v => v.Serie)
            .MaximumLength(150)
            .NotEmpty();
    }
}
