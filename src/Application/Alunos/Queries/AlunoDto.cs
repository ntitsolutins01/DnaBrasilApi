using DnaBrasil.Application.Ambientes.Queries.GetAmbientesAll;
using DnaBrasil.Application.Deficiencias.Queries.GetDeficienciasAll;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Alunos.Queries;
public class AlunoDto
{
    public int Id { get; set; }
    public required int AspNetUserId { get; set; }
    public Municipio? Municipio { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Sexo { get; set; }
    public required DateTime DtNascimento { get; set; }
    public string? NomeMae { get; set; }
    public string? NomePai { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? RedeSocial { get; set; }
    public string? Url { get; set; }
    public bool Status { get; set; }
    public bool Habilitado { get; set; }
    public List<DeficienciaDto>? Deficiencias { get; set; } = new();
    public List<AmbienteDto>? Ambientes { get; set; } = new();
    public Parceiro? Parceiro { get; set; }
    public int? Etnia { get; set; }
    public MatriculaDto? Matricula { get; set; }
    public List<VoucherDto>? Vouchers { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoDto>();
        }
    }
}
