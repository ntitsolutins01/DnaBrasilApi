using DnaBrasilApi.Application.Eventos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Eventos.Queries;

public class EventoDto
{
    public required int Id { get; set; }
    public required Localidade Localidade { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataEvento { get; set; }
    public bool Status { get; set; }
   

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Evento, EventoDto>();
        }
    }
}
