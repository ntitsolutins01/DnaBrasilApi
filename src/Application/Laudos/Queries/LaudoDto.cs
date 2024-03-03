using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class LaudoDto
{
    public int? TalentoEsportivoId { get; set; }
    public int? VocacionalId { get; set; }
    public int? QualidadeDeVidaId { get; set; }
    public int? SaudeId { get; set; }
    public int? ConsumoAlimentarId { get; set; }
    public int? SaudeBucalId { get; set; }
    public int? AlunoId { get; set; }
    public int? Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Laudo, LaudoDto>()
                .ForMember(dest => dest.TalentoEsportivoId, opt => opt.MapFrom(src => src.TalentoEsportivo!.Id))
                .ForMember(dest => dest.VocacionalId, opt => opt.MapFrom(src => src.Vocacional!.Id))
                .ForMember(dest => dest.QualidadeDeVidaId, opt => opt.MapFrom(src => src.QualidadeDeVida!.Id))
                .ForMember(dest => dest.SaudeId, opt => opt.MapFrom(src => src.Saude!.Id))
                .ForMember(dest => dest.ConsumoAlimentarId, opt => opt.MapFrom(src => src.Consumo!.Id))
                .ForMember(dest => dest.SaudeBucalId, opt => opt.MapFrom(src => src.SaudeBucal!.Id))
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id));
        }
    }
}
