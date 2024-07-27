using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Localidades.Queries;
public class LocalidadeDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; set; }
    public int MunicipioId { get; set; }
    public int EstadoId { get; set; }
    public string? NomeMunicipio { get; set; }
    public string? NomeEstado { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Localidade, LocalidadeDto>()
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio!.Id))
                .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.Municipio!.Estado!.Id))
                .ForMember(dest => dest.NomeMunicipio, opt => opt.MapFrom(src => src.Municipio!.Nome))
                .ForMember(dest => dest.NomeEstado, opt => opt.MapFrom(src => src.Municipio!.Estado!.Nome));
        }
    }
}
