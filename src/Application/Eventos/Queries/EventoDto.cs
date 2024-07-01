using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Eventos.Queries;

public class EventoDto
{
    public required int Id { get; set; }
    public required string Localidade { get; set; }
    public required string EstadoId { get; set; }
    public required string MunicipioId { get; set; }
    public required string LocalidadeId { get; set; }
    public required string Titulo { get; set; }
    public string? Descricao { get; set; }
    public required string DataEvento { get; set; }
    public bool Status { get; set; }
   

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Localidade.Municipio!.Id))
                .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.Localidade.Municipio!.Estado!.Sigla))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade.Id))
                .ForMember(dest => dest.DataEvento,
                    opt => opt.MapFrom(src => src.DataEvento.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Localidade, opt => opt.MapFrom(src => src.Localidade!.Nome));
        }
    }
}
