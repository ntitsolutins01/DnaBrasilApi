using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Commands.UpdateAluno;

public record UpdateAlunoCommand : IRequest
{
    public required int AspNetUserId { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required string Sexo { get; init; }
    public required DateTime DtNascimento { get; init; }
    public required int Etnia { get; init; }
    public string? NomeMae { get; init; }
    public string? NomePai { get; init; }
    public string? Cpf { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Cep { get; init; }
    public string? Endereco { get; init; }
    public string? Numero { get; init; }
    public string? Bairro { get; init; }
    public string? RedeSocial { get; init; }
    public string? Url { get; init; }
    public bool Status { get; init; }
    public bool Habilitado { get; init; }
    public List<Deficiencia>? Deficiencias { get; init; }
    public List<Ambiente>? Ambientes { get; init; }
    public Parceiro? Parceiro { get; init; }
}

public class UpdateAlunoCommandHandler : IRequestHandler<UpdateAlunoCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync(new object[] { request.AspNetUserId }, cancellationToken);

        Guard.Against.NotFound(request.AspNetUserId, entity);

        entity.AspNetUserId = request.AspNetUserId;
        entity.Nome = request.Nome;
        entity.Email = request.Email;
        entity.Sexo = request.Sexo;
        entity.DtNascimento = request.DtNascimento;
        entity.Etnia = request.Etnia;
        entity.NomeMae = request.NomeMae;
        entity.NomePai = request.NomePai;
        entity.Cpf = request.Cpf;
        entity.Telefone = request.Telefone;
        entity.Celular = request.Celular;
        entity.Endereco = request.Endereco;
        entity.Numero = request.Numero;
        entity.Bairro = request.Bairro;
        entity.RedeSocial = request.RedeSocial;
        entity.Url = request.Url;
        entity.Status = request.Status;
        entity.Habilitado = request.Habilitado;
        entity.Parceiro = request.Parceiro;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
