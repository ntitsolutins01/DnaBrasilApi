using System.Text.RegularExpressions;
using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Profissionais.Commands.PatchProfissional;

public class PatchProfissionalCommandValidator : AbstractValidator<PatchProfissionalCommand>
{
    private readonly IApplicationDbContext _context;

    public PatchProfissionalCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Nome)
            .MaximumLength(150)
            .NotEmpty();

        RuleFor(v => v.Sexo)
            .MaximumLength(1)
            .NotEmpty();
        
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
