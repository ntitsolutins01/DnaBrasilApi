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
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Cep { get; init; }
    public string? Endereco { get; init; }
    public string? Numero { get; init; }
    public string? Bairro { get; init; }
    public bool Status { get; init; }
    public bool Habilitado { get; init; }
    public required int MunicipioId { get; init; }
    public required int LocalidadeId { get; init; }
    public required int FomentoId { get; init; }
    public int? ProfissionalId { get; init; }
    public int? DeficienciaId { get; init; }
    public required string Etnia { get; init; }
    public int? LinhaAcaoId { get; init; }
    public string? NomeResponsavel { get; init; }
    public string? NomeFoto { get; init; }
    public byte[]? ByteImage { get; init; }
    public byte[]? QrCode { get; init; }
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

        var municipio = await _context.Municipios.FindAsync(new object[] { request.MunicipioId }, cancellationToken);

        Guard.Against.NotFound((int)request.MunicipioId, municipio);


        var localidade = await _context.Localidades.FindAsync(new object[] { request.LocalidadeId }, cancellationToken);

        Guard.Against.NotFound((int)request.LocalidadeId, localidade);


        var fomento = await _context.Fomentos.FindAsync(new object[] { request.FomentoId }, cancellationToken);

        Guard.Against.NotFound((int)request.FomentoId, fomento);

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

        LinhaAcao? linhaAcao = null;

        if (request.LinhaAcaoId != null)
        {
            linhaAcao = await _context.LinhasAcoes.FindAsync(new object[] { request.LinhaAcaoId }, cancellationToken);

            Guard.Against.NotFound((int)request.LinhaAcaoId, profissional);
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
            QrCode = request.QrCode,
            Status = request.Status,
            Habilitado = request.Habilitado,
            Municipio = municipio!,
            Localidade = localidade!,
            Deficiencia = deficiencia,
            LinhaAcao = linhaAcao,
            NomeResponsavel = request.NomeResponsavel,
            Profissional = profissional,
            Fomento = fomento
        };

        _context.Alunos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
