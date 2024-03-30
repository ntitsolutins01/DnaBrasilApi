    using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.TodoItems.Commands.CreateTodoItem;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.Events;

namespace DnaBrasilApi.Application.Alunos.Commands.CreateAluno;

public record CreateAlunoCommand : IRequest<int>
{
    public string? AspNetUserId { get; init; }
    public required string Nome { get; init; }
    public required string Email { get; init; }
    public required string Sexo { get; init; }
    public required string DtNascimento { get; init; }
    public string? NomeMae { get; init; }
    public string? NomePai { get; init; }
    public string? Cpf { get; init; }
    public string? Telefone { get; init;}
    public string? Celular { get; init;}
    public string? Cep { get; init;}
    public string? Endereco { get; init;}
    public string? Numero { get; init; }
    public string? Bairro { get; init; }
    public bool Status { get; init;}
    public bool Habilitado { get; init;}
    public int? MunicipioId { get; init; }
    public int? LocalidadeId { get; init; }
    public int? ProfissionalId { get; init; }
    public int? DeficienciaId { get; init; }
    public required string Etnia { get; init; }
    public string? AreasDesejadas { get; init; }
    public string? NomeResponsavel { get; init; }
    public string? NomeFoto { get; init; }
    public byte[]? ByteImage { get; init; }
}

public class CreateAlunoCommandHandler : IRequestHandler<CreateAlunoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
    {
        Municipio? municipio = null;

        if (request.MunicipioId != null)
        {
            municipio = await _context.Municipios.FindAsync(new object[] { request.MunicipioId }, cancellationToken);

            Guard.Against.NotFound((int)request.MunicipioId, municipio);
        }

        Localidade? localidade = null;

        if (request.LocalidadeId != null)
        {
            localidade = await _context.Localidades.FindAsync(new object[] { request.LocalidadeId }, cancellationToken);

            Guard.Against.NotFound((int)request.LocalidadeId, localidade);
        }

        Deficiencia? deficiencia = null;

        if (request.DeficienciaId != null)
        {
            deficiencia = await _context.Deficiencias.FindAsync(new object[] { request.DeficienciaId }, cancellationToken);

            Guard.Against.NotFound((int)request.DeficienciaId, deficiencia);
        }
        
        //Parceiro? parceiro = null;

        //if (request.ParceiroId != null)
        //{
        //    parceiro = await _context.Parceiros.FindAsync(new object[] { request.ParceiroId }, cancellationToken);

        //    Guard.Against.NotFound((int)request.ParceiroId, parceiro);
        //}

        Profissional? profissional = null;

        if (request.ProfissionalId != null)
        {
            profissional = await _context.Profissionais.FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

            Guard.Against.NotFound((int)request.ProfissionalId, profissional);
        }

        var entity = new Aluno
        {
            AspNetUserId = request.AspNetUserId,
            Nome = request.Nome,
            Email = request.Email,
            Sexo = request.Sexo,
            DtNascimento = DateTime.ParseExact(request.DtNascimento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
            Etnia = request.Etnia,
            NomeMae = request.NomeMae,
            NomePai = request.NomePai,
            Cpf = request.Cpf,
            Telefone = request.Telefone,
            Celular = request.Celular,
            Endereco = request.Endereco,
            Numero = request.Numero,
            Bairro = request.Bairro,
            NomeFoto = request.NomeFoto,
            ByteImage = request.ByteImage,
            Status = request.Status,
            Habilitado = request.Habilitado,
            Municipio = municipio!,
            Localidade = localidade!,
            Deficiencia = deficiencia,
            AreasDesejadas = request.AreasDesejadas,
            NomeResponsavel = request.NomeResponsavel,
            Profissional = profissional
        };

        _context.Alunos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
