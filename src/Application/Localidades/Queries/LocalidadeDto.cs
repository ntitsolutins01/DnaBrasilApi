using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Localidades.Queries;
public class LocalidadeDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; init; }
    public int MunicipioId { get; init; }
    public int EstadoId { get; init; }
    public string? NomeMunicipio { get; init; }
    public string? NomeEstado { get; init; }
    public int? CodigoInep { get; init; }

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
