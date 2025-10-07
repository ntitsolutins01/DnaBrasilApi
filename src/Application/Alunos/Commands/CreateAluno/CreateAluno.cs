using System.Globalization;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

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
    public string? NomeFoto { get; init; }
    public byte[]? ByteImage { get; init; }
    public byte[]? QrCode { get; init; }
    public bool? AutorizacaoSaida { get; init; }
    public bool? AutorizacaoConsentimentoAssentimento { get; init; }
    public bool? ParticipacaoProgramaCompartilhamentoDados { get; init; }
    public bool? UtilizacaoImagem { get; init; }
    public bool? CopiaDocAlunoResponsavel { get; init; }
    public bool? Convidado { get; init; } = false;
    public string? ModalidadesIds { get; init; }
    public int? SerieId { get; init; }
    public required string NomeResponsavel { get; init; }
    public required int GrauParentescoId { get; init; }
    public required string CpfResponsavel { get; init; }
    public required string TelefoneResponsavel { get; init; }
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
        var municipio = await _context.Municipios.FindAsync([request.MunicipioId], cancellationToken);

        Guard.Against.NotFound((int)request.MunicipioId, municipio);


        var localidade = await _context.Localidades.FindAsync([request.LocalidadeId], cancellationToken);

        Guard.Against.NotFound((int)request.LocalidadeId, localidade);


        var fomento = await _context.Fomentos.FindAsync([request.FomentoId], cancellationToken);

        Guard.Against.NotFound((int)request.FomentoId, fomento);

        Deficiencia? deficiencia = null;

        if (request.DeficienciaId != null)
        {
            deficiencia = await _context.Deficiencias.FindAsync([request.DeficienciaId], cancellationToken);

            Guard.Against.NotFound((int)request.DeficienciaId, deficiencia);
        }

        Profissional? profissional = null;

        if (request.ProfissionalId != null)
        {
            profissional = await _context.Profissionais.FindAsync([request.ProfissionalId], cancellationToken);

            Guard.Against.NotFound((int)request.ProfissionalId, profissional);
        }

        LinhaAcao? linhaAcao = null;

        if (request.LinhaAcaoId != null)
        {
            linhaAcao = await _context.LinhasAcoes.FindAsync([request.LinhaAcaoId], cancellationToken);

            Guard.Against.NotFound((int)request.LinhaAcaoId, profissional);
        }

        Serie? serie = null;

        if (request.SerieId != null)
        {
            serie = await _context.Series.FindAsync([request.SerieId], cancellationToken);

            Guard.Against.NotFound((int)request.SerieId, serie);
        }

        var grauParentesco = await _context.GrauParentescos.FindAsync([request.GrauParentescoId], cancellationToken);

        Guard.Against.NotFound(request.GrauParentescoId, grauParentesco);

        Responsavel responsavel = new()
        {
            Nome = request.NomeResponsavel,
            Cpf = request.CpfResponsavel,
            Telefone = request.TelefoneResponsavel,
            GrauParentesco = grauParentesco,
        };


        var entity = new Aluno
        {
            AspNetUserId = request.AspNetUserId,
            Nome = request.Nome,
            Email = request.Email,
            Sexo = request.Sexo,
            DtNascimento = DateTime.ParseExact(request.DtNascimento,
                "dd/MM/yyyy",
                CultureInfo.CreateSpecificCulture("pt-BR")),
            Etnia = request.Etnia,
            NomeMae = request.NomeMae,
            NomePai = request.NomePai,
            Cep = request.Cep,
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
            Municipio = municipio,
            Localidade = localidade,
            Deficiencia = deficiencia,
            LinhaAcao = linhaAcao,
            Profissional = profissional,
            Fomento = fomento,
            AutorizacaoSaida = request.AutorizacaoSaida,
            AutorizacaoConsentimentoAssentimento = request.AutorizacaoConsentimentoAssentimento,
            ParticipacaoProgramaCompartilhamentoDados = request.ParticipacaoProgramaCompartilhamentoDados,
            UtilizacaoImagem = request.UtilizacaoImagem,
            CopiaDocAlunoResponsavel = request.CopiaDocAlunoResponsavel,
            Convidado = (bool)request.Convidado!,
            Serie = serie,
            Responsavel = responsavel
        };

        _context.Alunos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        var listAlunoModalidades = new List<AlunoModalidade>();

        if (!string.IsNullOrEmpty(request.ModalidadesIds))
        {
            int[] arrModIds = request.ModalidadesIds.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            listAlunoModalidades.AddRange(arrModIds.Select(item => new AlunoModalidade() { ModalidadeId = item, AlunoId = entity.Id }));
        }

        entity.AlunoModalidades = listAlunoModalidades;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
