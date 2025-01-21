using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.TiposParcerias.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Parceiros.Queries;
public class ParceiroDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Email { get; init; }
    public List<ProfissionalDto> Profissionais { get; } = new();
    public string? TipoPessoa { get; init; }
    public string? CpfCnpj { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Cep { get; init; }
    public string? Endereco { get; init; }
    public int Numero { get; init; }
    public string? Bairro { get; init; }
    public int EstadoId { get; init; }
    public string? Uf { get; init; }
    public int MunicipioId { get; init; }
    public bool Status { get; init; }
    public bool? Habilitado { get; init; }
    public List<AlunoDto>? Alunos { get; init; }
    public required TipoParceriaDto? TipoParceria { get; init; }
    public required string RazaoSocial { get; init; }
    public required string NomeContato { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Parceiro, ParceiroDto>()
            .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id))
            .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.Municipio!.Estado!.Id))
            .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Municipio!.Estado!.Sigla));
        }
    }
}
