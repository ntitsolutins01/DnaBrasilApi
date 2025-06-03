using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomentos.Queries;
public class FomentoDto
{
    public int Id { get; init; }
    public string? IdIdMunicipio { get; init; }
    public string? Codigo { get; init; }
    public string? Nome { get; init; }
    public string? MunicipioEstado { get; init; }
    public string? MunicipioId { get; init; }
    public string? Localidades { get; init; }
    public string? LocalidadeId { get; init; }
    public string? DtIni { get; init; }
    public string? DtFim { get; init; }
    public bool Status { get; init; }
    public string? Sigla { get; init; }
    public string? LinhasAcoesIds { get; init; }
    public string? LocalidadesIds { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Fomentu, FomentoDto>()
                .ForMember(dest => dest.DtIni, opt => opt.MapFrom(src => src.DtIni.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.DtFim, opt => opt.MapFrom(src => src.DtFim.ToString("dd/MM/yyyy")))
                //.ForMember(dest => dest.Localidades, 
                //    opt => opt.MapFrom(src =>
                //        src.FomentoLocalidades == null
                //            ? ""
                //            : string.Join(",", src.FomentoLocalidades!.Select(s => s.Localidade!.Nome!.ToString()).ToArray())))
                .ForMember(dest => dest.LinhasAcoesIds,
                    opt => opt.MapFrom(src =>
                        src.FomentoLinhasAcoes == null
                            ? ""
                            : string.Join(",", src.FomentoLinhasAcoes!.Select(s => s.LinhaAcaoId.ToString()).ToArray())))
                .ForMember(dest => dest.LocalidadesIds,
                    opt => opt.MapFrom(src =>
                        src.FomentoLocalidades == null
                            ? ""
                            : string.Join(",", src.FomentoLocalidades!.Select(s => s.LocalidadeId.ToString()).ToArray())))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id.ToString()))
                .ForMember(dest => dest.Sigla, opt => opt.MapFrom(src => src.Municipio!.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.IdIdMunicipio, opt => opt.MapFrom(src => $"{src.Id}-{src.Municipio!.Id}"))
                .ForMember(dest => dest.MunicipioEstado,
                    opt => opt.MapFrom(src =>
                        src.Municipio!.Nome!.ToString() + " / " + src.Municipio!.Estado!.Sigla!.ToString()));
        }
    }

}
