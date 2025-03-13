using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Inventarios.Queries;
public class InventarioIndexDto
{
    public required int Id { get; set; }
    public required string NomeMaterial { get; set; }
    public required string NomeLocalidade { get; set; }
    public int? Quantidade { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Inventario, InventarioIndexDto>()
                .ForMember(dest => dest.NomeMaterial, opt => opt.MapFrom(src => src.Material.Descricao))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade.Nome));
        }
    }
}
