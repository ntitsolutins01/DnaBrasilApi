using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomentos.Queries;
public class FomentoDto
{
    public int Id { get; set; }
    public string? IdIdMunicipio { get; set; }
    public string? Codigo { get; set; }
    public string? Nome { get; set; }
    public string? MunicipioEstado { get; set; }
    public string? MunicipioId { get; set; }
    public string? Localidade { get; set; }
    public string? LocalidadeId { get; set; }
    public string? DtIni { get; set; }
    public string? DtFim { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Fomentu, FomentoDto>()
                .ForMember(dest => dest.DtIni, opt => opt.MapFrom(src => src.DtIni.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.DtFim, opt => opt.MapFrom(src => src.DtFim.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Localidade, opt => opt.MapFrom(src => src.Localidade.Nome!.ToString()))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade.Id!.ToString()))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id.ToString()))
                .ForMember(dest => dest.IdIdMunicipio, opt => opt.MapFrom(src => $"{src.Id}-{src.Municipio!.Id}"))
                .ForMember(dest => dest.MunicipioEstado, opt => opt.MapFrom(src => src.Municipio!.Nome!.ToString() +" / "+ src.Municipio!.Estado!.Sigla!.ToString()));
        }
    }

}
