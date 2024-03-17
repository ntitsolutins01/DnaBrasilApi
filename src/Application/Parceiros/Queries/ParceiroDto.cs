using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Parceiros.Queries;
public class ParceiroDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public bool Status { get; set; }
    public List<AlunoDto>? Alunos { get; set; }
    public List<ProfissionalDto> Profissionais { get; } = new();
    public int TipoParceria { get; set; }
    public string? TipoPessoa { get; set; }
    public string? CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public int Numero { get; set; }
    public string? Bairro { get; set; }
    public int EstadoId { get; set; }
    public string? Uf { get; set; }
    public int MunicipioId { get; set; }
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
