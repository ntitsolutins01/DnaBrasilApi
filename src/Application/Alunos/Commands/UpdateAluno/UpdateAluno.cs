using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateAluno;

public record UpdateAlunoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? AspNetUserId { get; init; }
    public string? Nome { get; init; }
    public string? Email { get; init; }
    public string? Sexo { get; init; }
    public string? DtNascimento { get; init; }
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
    public string? Etnia { get; set; }
    public int ProfissionalId { get; set; }
}

public class UpdateAlunoCommandHandler : IRequestHandler<UpdateAlunoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);


        var profissional = await _context.Profissionais
            .FindAsync([request.ProfissionalId], cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        entity.AspNetUserId = request.AspNetUserId;
        entity.Nome = request.Nome!;
        entity.Email = request.Email!;
        entity.Sexo = request.Sexo!;
        entity.DtNascimento = DateTime.ParseExact(request.DtNascimento!, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); ;
        entity.NomeMae = request.NomeMae;
        entity.NomePai = request.NomePai;
        entity.Cpf = request.Cpf;
        entity.Telefone = request.Telefone;
        entity.Celular = request.Celular;
        entity.Endereco = request.Endereco;
        entity.Numero = request.Numero;
        entity.Bairro = request.Bairro;
        entity.Url = request.Url;
        entity.Status = request.Status;
        entity.Habilitado = request.Habilitado;
        entity.Parceiro = request.Parceiro;
        entity.Profissional = profissional;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
