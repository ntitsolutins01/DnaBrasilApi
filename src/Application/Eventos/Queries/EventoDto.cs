using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Eventos.Queries;

public class EventoDto
{
    public required int Id { get; set; }
    public required string Localidade { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public required string DataEvento { get; set; }
    public bool Status { get; set; }
   

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.DataEvento,
                    opt => opt.MapFrom(src => src.DataEvento.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Localidade, opt => opt.MapFrom(src => src.Localidade!.Nome));
        }
    }
}
