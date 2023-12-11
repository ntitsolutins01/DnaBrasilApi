using DnaBrasilApi.Application.Ambientes.Queries;
using DnaBrasilApi.Application.Contratos.Queries;
using DnaBrasilApi.Application.Deficiencias.Queries;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Localidades.Queries;
using DnaBrasilApi.Application.Municipios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunoDto
{
    public int Id { get; set; }
    public  int AspNetUserId { get; set; }
    public  string? Nome { get; set; }
    public  string? Email { get; set; }
    public  string? Sexo { get; set; }
    public  DateTime DtNascimento { get; set; }
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
    public int? Etnia { get; set; }
    public int? IdCliente { get; set; }


    public MunicipioDto? Municipio { get; set; }
    public LocalidadeDto? Localidade { get; set; }
    public Parceiro? Parceiro { get; set; }
    public List<DeficienciaDto>? Deficiencias { get; set; }
    public List<AmbienteDto>? Ambientes { get; set; }
    public List<ContratoDto>? Contratos { get; set; }
    public MatriculaDto? Matricula { get; set; }
    public VoucherDto? Voucher { get; set; }
    //public DependenciaDto? Dependencia { get; set; }
    public List<LaudoDto>? Laudos { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Aluno, AlunoDto>();
        }
    }
}
