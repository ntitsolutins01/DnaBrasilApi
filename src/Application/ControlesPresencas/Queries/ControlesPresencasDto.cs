using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries;
public class ControlesPresencasDto
{
    public int Id { get; set; }
    public int? EventoId { get; set; }
    public required string Controle { get; set; }
    public string? Justificativa { get; set; }
    public string? Data { get; set; }
    public bool Status { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControlePresenca, ControlesPresencasDto>()
                .ForMember(dest => dest.EventoId, opt => opt.MapFrom(src => src.Evento!.Id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Created.ToString("dd/MM/yyyy")));
        }
    }
}
