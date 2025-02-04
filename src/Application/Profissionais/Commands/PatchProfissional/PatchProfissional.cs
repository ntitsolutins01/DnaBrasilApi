using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Commands.PatchProfissional;

public record PatchProfissionalCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Cpf { get; init; }
    public string? DtNascimento { get; init; }
    public string? Sexo { get; init; }
    public string? Endereco { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public int? Numero { get; init; }
    public string? Cep { get; init; }
    public string? Bairro { get; init; }
}

public class PatchProfissionalCommandHandler : IRequestHandler<PatchProfissionalCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public PatchProfissionalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(PatchProfissionalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Profissionais
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Nome = request.Nome!;
        entity.DtNascimento = DateTime.ParseExact(request.DtNascimento!, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
        entity.Sexo = request.Sexo;
        entity.Telefone = request.Telefone;
        entity.Celular = request.Celular;
        entity.Endereco = request.Endereco;
        entity.Numero = request.Numero;
        entity.Cep = request.Cep;
        entity.Bairro = request.Bairro;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;//true
    }
}
