using DnaBrasil.Application.Alunos.Commands.CreateAluno;

namespace DnaBrasil.Application.TodoItems.Commands.CreateTodoItem;

public class CreateAlunoCommandValidator : AbstractValidator<CreateAlunoCommand>
{
    public CreateAlunoCommandValidator()
    {
        RuleFor(v => v.Nome)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(t => t.Nome)
            .MaximumLength(150)
            .NotEmpty();
        RuleFor(t => t.Email)
            .MaximumLength(100)
            .NotEmpty();
        RuleFor(t => t.DtNascimento)
            .NotEmpty();
        RuleFor(t => t.Sexo)
            .MaximumLength(1)
            .NotEmpty();
        RuleFor(t => t.NomePai)
            .MaximumLength(150);
        RuleFor(t => t.NomeMae)
            .MaximumLength(150);
        RuleFor(t => t.Cpf)
            .MaximumLength(14);
        RuleFor(t => t.Telefone)
            .MaximumLength(13);
        RuleFor(t => t.Celular)
            .MaximumLength(13);
        RuleFor(t => t.Cep)
            .MaximumLength(8);
        RuleFor(t => t.Endereco)
            .MaximumLength(200);
        RuleFor(t => t.Bairro)
            .MaximumLength(50);
        RuleFor(t => t.RedeSocial)
            .MaximumLength(100);
        RuleFor(t => t.Url)
            .MaximumLength(200);
    }
}
