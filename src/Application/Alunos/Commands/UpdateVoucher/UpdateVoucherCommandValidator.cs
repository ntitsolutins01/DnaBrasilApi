using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateVoucher;

public class UpdateVoucherCommandValidator : AbstractValidator<UpdateVoucherCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateVoucherCommandValidator(IApplicationDbContext context)
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
