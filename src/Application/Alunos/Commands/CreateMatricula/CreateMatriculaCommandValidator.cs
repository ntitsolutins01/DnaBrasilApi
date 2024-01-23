using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateMatricula;
public class CreateMatriculaCommandValidator : AbstractValidator<CreateMatriculaCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateMatriculaCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        //    RuleFor(v => v.DtVencimentoParq)
        //    .InclusiveBetween(new DateTime(1900, 01, 01), new DateTime(2050, 01, 01))
        //    .WithMessage("'{PropertyName}' deve ser maior que 01/01/1980 e menor que 01/01/2050.")
        //    .NotEmpty();
        //RuleFor(v => v.DtVencimentoAtestadoMedico)
        //    .InclusiveBetween(new DateTime(1900, 01, 01), new DateTime(2050, 01, 01))
        //    .WithMessage("'{PropertyName}' deve ser maior que 01/01/1980 e menor que 01/01/2050.")
        //    .NotEmpty();
        //RuleFor(v => v.NomeResponsavel1)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.CpfResponsavel1)
        //    .NotEmpty()
        //    .MaximumLength(14)
        //    .MustAsync(BeUniquCpf)
        //    .WithMessage("'{PropertyName}' deve ser único.")
        //    .WithErrorCode("Unique");
        //RuleFor(v => v.ParentescoResponsavel1)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.NomeResponsavel2)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.CpfResponsavel2)
        //    .NotEmpty()
        //    .MaximumLength(14)
        //    .MustAsync(BeUniquCpf)
        //    .WithMessage("'{PropertyName}' deve ser único.")
        //    .WithErrorCode("Unique");
        //RuleFor(v => v.ParentescoResponsavel2)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.NomeResponsavel3)
        //    .MaximumLength(150)
        //    .NotEmpty();
        //RuleFor(v => v.CpfResponsavel3)
        //    .NotEmpty()
        //    .MaximumLength(14)
        //    .MustAsync(BeUniquCpf)
        //    .WithMessage("'{PropertyName}' deve ser único.")
        //    .WithErrorCode("Unique");
        //RuleFor(v => v.ParentescoResponsavel3)
        //    .MaximumLength(150)
        //    .NotEmpty();
    }
    public async Task<bool> BeUniquCpf(string cpf, CancellationToken cancellationToken)
    {
        return await _context.Profissionais
            .AllAsync(l => l.CpfCnpj != cpf, cancellationToken);
    }
}
