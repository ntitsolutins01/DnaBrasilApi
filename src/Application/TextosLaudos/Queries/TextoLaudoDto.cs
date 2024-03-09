using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TextosLaudos.Queries;
public class TextoLaudoDto
{
    public int Id { get; set; }
    public int? TipoLaudoId { get; init; }
    public int? Idade { get; init; }
    public string? Sexo { get; init; }
    public string? NomeTipoLaudo { get; init; }
    public string? Classificacao { get; init; }
    public decimal PontoInicial { get; init; }
    public decimal PontoFinal { get; init; }
    public string? Aviso { get; init; }
    public string? Texto { get; init; }
    public bool Status { get; init; } = true;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TextoLaudo, TextoLaudoDto>()
                .ForMember(dest => dest.TipoLaudoId, opt => opt.MapFrom(src => src.TipoLaudo!.Id))
                .ForMember(dest => dest.NomeTipoLaudo, opt => opt.MapFrom(src => src.TipoLaudo!.Nome));
        }
    }
}
