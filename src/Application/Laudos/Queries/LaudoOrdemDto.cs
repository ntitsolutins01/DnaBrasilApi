using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class LaudoOrdemDto
{
    public int Id { get; init; }
    public int? Ordem { get; init; }
    public DateTimeOffset? DataCriacao { get; init; }
    public int? TalentoEsportivoId { get; init; }
    public int? QualidadeDeVidaId { get; init; }
    public int? VocacionalId { get; init; }
    public int? SaudeId { get; init; }
    public int? SaudeBucalId { get; init; }
    public int? ConsumoAlimentarId { get; init; }
    public string? StatusLaudo { get; init; }
    public string? Sexo { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Laudo, LaudoOrdemDto>()
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.TalentoEsportivoId, opt => opt.MapFrom(src => src.TalentoEsportivo!.Id))
                .ForMember(dest => dest.QualidadeDeVidaId, opt => opt.MapFrom(src => src.QualidadeDeVida!.Id))
                .ForMember(dest => dest.VocacionalId, opt => opt.MapFrom(src => src.Vocacional!.Id))
                .ForMember(dest => dest.SaudeId, opt => opt.MapFrom(src => src.Saude!.Id))
                .ForMember(dest => dest.SaudeBucalId, opt => opt.MapFrom(src => src.SaudeBucal!.Id))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Aluno!.Sexo))
                .ForMember(dest => dest.ConsumoAlimentarId, opt => opt.MapFrom(src => src.ConsumoAlimentar!.Id));
        }
    }
}
