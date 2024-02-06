using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomentos.Queries;
public class FomentoDto
{
    public int Id { get; init; }
    public string? Codigo { get; init; }
    public string? Nome { get; init; }
    public string? MunicipioEstado { get; init; }
    public string? Localidade { get; init; }
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
                .ForMember(dest => dest.MunicipioEstado, opt => opt.MapFrom(src => src.Municipio!.Nome!.ToString() +" / "+ src.Municipio!.Estado!.Sigla!.ToString()));
        }
    }

}
