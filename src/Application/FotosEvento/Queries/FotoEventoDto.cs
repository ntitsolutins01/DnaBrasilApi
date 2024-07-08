using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.FotosEvento.Queries;

public class FotoEventoDto
{
    public required int Id { get; set; }
    public required string NomeEvento { get; set; }
    public required string NomeArquivo { get; set; }
    public required string Url { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FotoEvento, FotoEventoDto>()
                .ForMember(dest => dest.NomeEvento, opt => opt.MapFrom(src => src.Evento.Titulo));
        }
    }
}
