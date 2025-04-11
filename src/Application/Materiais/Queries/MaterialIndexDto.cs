using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Materiais.Queries;
public class MaterialIndexDto
{
    public required int Id { get; set; }
    public required string TituloTipoMaterial { get; set; }
    public required string UnidadeMedida { get; set; }
    public required string Descricao { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Material, MaterialIndexDto>()
                .ForMember(dest => dest.TituloTipoMaterial, opt => opt.MapFrom(src => src.TipoMaterial.Nome));
        }
    }
}
