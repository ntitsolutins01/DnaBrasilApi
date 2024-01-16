using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomentos.Queries;
public class FomentoDto
{
    public int Id { get; init; }
    public string? Codigo { get; init; }
    public string? Nome { get; init; }
    public Municipio? Municipio { get; init; }
    public Localidade? Localidade { get; init; }
    public string? DtIni { get; set; }
    public string? DtFim { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Fomentu, FomentoDto>()
                .ForMember(dest => dest.DtIni, opt => opt.MapFrom(src => src.DtIni.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.DtFim, opt => opt.MapFrom(src => src.DtFim.ToString("dd/MM/yyyy")));
        }
    }

}
