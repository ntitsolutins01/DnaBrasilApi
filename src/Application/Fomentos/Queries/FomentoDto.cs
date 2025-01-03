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
    public string? Localidades { get; set; }
    public string? LocalidadeId { get; set; }
    public string? DtIni { get; set; }
    public string? DtFim { get; set; }
    public bool Status { get; set; }
    public string? Sigla { get; set; }
    public string? LinhaAcoes { get; set; }
    public string? LocalidadesId { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Fomentu, FomentoDto>()
                .ForMember(dest => dest.DtIni, opt => opt.MapFrom(src => src.DtIni.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.DtFim, opt => opt.MapFrom(src => src.DtFim.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Localidades, 
                    opt => opt.MapFrom(src =>
                        src.FomentoLocalidades == null
                            ? ""
                            : string.Join(",", src.FomentoLocalidades!.Select(s => s.Localidade!.Nome!.ToString()).ToArray())))
                .ForMember(dest => dest.LinhaAcoes,
                    opt => opt.MapFrom(src =>
                        src.FomentoLinhasAcoes == null
                            ? ""
                            : string.Join(",", src.FomentoLinhasAcoes!.Select(s => s.LinhaAcaoId.ToString()).ToArray())))
                .ForMember(dest => dest.LocalidadesId,
                    opt => opt.MapFrom(src =>
                        src.FomentoLocalidades == null
                            ? ""
                            : string.Join(",", src.FomentoLocalidades!.Select(s => s.FomentoId.ToString()).ToArray())))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id.ToString()))
                .ForMember(dest => dest.Sigla, opt => opt.MapFrom(src => src.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.IdIdMunicipio, opt => opt.MapFrom(src => $"{src.Id}-{src.Municipio!.Id}"))
                .ForMember(dest => dest.MunicipioEstado,
                    opt => opt.MapFrom(src =>
                        src.Municipio!.Nome!.ToString() + " / " + src.Municipio!.Estado!.Sigla!.ToString()));
        }
    }

}
