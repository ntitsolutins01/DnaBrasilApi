using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Profissionais.Commands.CreateProfissional;

public class CreateProfissionalCommandValidator : AbstractValidator<CreateProfissionalCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProfissionalCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();

        RuleFor(v => v.DtNascimento)
            .InclusiveBetween(new DateTime(1900, 01, 01), new DateTime(2050, 01, 01))
            .WithMessage("'{PropertyName}' deve ser maior que 01/01/1980 e menor que 01/01/2050.")
            .NotEmpty();

        RuleFor(v => v.Sexo)
            .MaximumLength(1)
            .NotEmpty();

        RuleFor(v => v.Email)
            .MaximumLength(100)
            .NotEmpty().WithMessage("É necessário um endereço de e-mail")
            .EmailAddress().WithMessage("É necessário um e-mail válido");

        RuleFor(v => v.Cpf)
            .NotEmpty()
            .MaximumLength(14)
            .MustAsync(BeUniquCpf)
                .WithMessage("'{PropertyName}' deve ser único.")
                .WithErrorCode("Unique");

        RuleFor(v => v.Telefone)
            .MaximumLength(14);

        RuleFor(v => v.Celular)
            .MaximumLength(14);

        RuleFor(v => v.Celular)
            .MaximumLength(14);

        RuleFor(v => v.Endereco)
            .MaximumLength(200);

        RuleFor(v => v.Bairro)
            .MaximumLength(100);

        RuleFor(v => v.Cep)
            .MaximumLength(9);

        RuleFor(v => v.Status)
            .NotNull().NotEmpty();
    }

    public async Task<bool> BeUniquCpf(string cpf, CancellationToken cancellationToken)
    {
        return await _context.Profissionais
            .AllAsync(l => l.Cpf != cpf, cancellationToken);
    }
}
