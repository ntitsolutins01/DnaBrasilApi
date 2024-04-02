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
    public string? NomeFoto { get; init; }
    public byte[]? ByteImage { get; init; }
    public byte[]? QrCode { get; set; }
    public bool Status { get; init; }
    public bool Habilitado { get; init; }
    public int? MunicipioId { get; init; }
    public int? LocalidadeId { get; init; }
    public int? DeficienciaId { get; init; }
    public int? ParceiroId { get; init; }
    public string? Etnia { get; set; }
    public int? ProfissionalId { get; set; }
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

        int result;
        if (request.QrCode!=null)
        {
            entity.QrCode = request.QrCode;
            result = await _context.SaveChangesAsync(cancellationToken);

            return result == 1;//true
        }
        else
        {
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
            entity.Status = request.Status;
            entity.Habilitado = request.Habilitado;
            //entity.Parceiro = parceiro;
            entity.Profissional = profissional;
            entity.NomeFoto = request.NomeFoto;
            entity.ByteImage = request.ByteImage;
            entity.QrCode = request.QrCode;
        }


        result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;//true
    }
}
