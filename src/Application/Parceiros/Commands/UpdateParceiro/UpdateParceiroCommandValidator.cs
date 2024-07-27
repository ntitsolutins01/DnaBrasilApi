using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Parceiros.Commands.UpdateParceiro;

public class UpdateParceiroCommandValidator : AbstractValidator<UpdateParceiroCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateParceiroCommandValidator(IApplicationDbContext context)
    {

        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();


        RuleFor(v => v.Email)
            .MaximumLength(100)
            .NotEmpty().WithMessage("É necessário um endereço de e-mail")
            .EmailAddress().WithMessage("É necessário um e-mail válido");

        RuleFor(v => v.Endereco)
            .MaximumLength(200);

        RuleFor(v => v.Bairro)
            .MaximumLength(100);

        RuleFor(v => v.Cep)
            .MaximumLength(9);
    }

    public async Task<bool> BeUniquCpf(string cpf, CancellationToken cancellationToken)
    {
        return await _context.Profissionais
            .AllAsync(l => l.CpfCnpj != cpf, cancellationToken);
    }
}
