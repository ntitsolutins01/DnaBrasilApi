namespace DnaBrasilApi.Application.Parceiros.Commands.CreateParceiro;

public class CreateParecrioCommandValidator : AbstractValidator<CreateParceiroCommand>
{
    public CreateParecrioCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotNull().NotEmpty();
        RuleFor(v => v.Email)
            .MaximumLength(100)
            .NotNull().NotEmpty();
        RuleFor(v => v.TipoPessoa)
            .NotNull().NotEmpty();
        RuleFor(v => v.CpfCnpj)
            .MaximumLength(18)
            .NotNull().NotEmpty();
        RuleFor(v => v.Telefone)
            .MaximumLength(13)
            .NotNull().NotEmpty();
        RuleFor(v => v.Celular)
            .MaximumLength(13)
            .NotNull().NotEmpty();
        RuleFor(v => v.Cep)
            .MaximumLength(9)
            .NotNull().NotEmpty();
        RuleFor(v => v.Endereco)
            .MaximumLength(200)
            .NotNull().NotEmpty();
        RuleFor(v => v.Bairro)
            .MaximumLength(50)
            .NotNull().NotEmpty();
    }
}
