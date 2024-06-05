using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TextosLaudos.Queries;
public class TextoLaudoDto
{
    public int Id { get; set; }
    public int? TipoLaudoId { get; set; }
    public int? Idade { get; set; }
    public string? Sexo { get; set; }
    public string? NomeTipoLaudo { get; set; }
    public string? Classificacao { get; set; }
    public decimal PontoInicial { get; set; }
    public decimal PontoFinal { get; set; }
    public string? Aviso { get; set; }
    public string? Texto { get; set; }
    public bool Status { get; set; } = true;
    public int? Quadrante { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TextoLaudo, TextoLaudoDto>()
                .ForMember(dest => dest.TipoLaudoId, opt => opt.MapFrom(src => src.TipoLaudo!.Id))
                .ForMember(dest => dest.NomeTipoLaudo, opt => opt.MapFrom(src => src.TipoLaudo!.Nome))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo == "F" ? "Feminino" : src.Sexo == "M" ? "Masculino" : "Geral"));
        }
    }
}
