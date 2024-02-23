using DnaBrasilApi.Application.Modalidades.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Queries;
public class ProfissionalDto
{
    public int Id { get; set; }
    public string? AspNetUserId { get; set; }
    public required string Nome { get; set; }
    public string? DtNascimento { get; set; }
    public required string Email { get; set; }
    public string? Sexo { get; set; }
    public required string CpfCnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Celular { get; set; }
    public string? Endereco { get; set; }
    //public int? Numero { get; set; }
    public string? Cep { get; set; }
    public string? Bairro { get; set; }
    public bool Status { get; set; } = true;
    public bool Habilitado { get; set; }
    public List<ModalidadeDto>? Modalidades { get; set; }
    //public List<Contrato>? Contratos { get; set; }
    public int EstadoId { get; set; }
    public string? Uf { get; set; }
    public int? MunicipioId { get; set; }
    public int? LocalidadeId { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Profissional, ProfissionalDto>()
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id))
                .ForMember(dest => dest.LocalidadeId, opt =>opt.MapFrom(src => src.Localidade!.Id))
                .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.Municipio!.Estado!.Id))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Municipio!.Estado!.Sigla))
                .ForMember(dest => dest.DtNascimento,
                    opt => opt.MapFrom(src => src.DtNascimento!.Value.ToString("dd/MM/yyyy")));
        }
    }
}
