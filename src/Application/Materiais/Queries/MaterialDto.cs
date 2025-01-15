using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Materiais.Queries;

public class MaterialDto
{
    public required int Id { get; init; }
    public required int TipoMaterialId { get; init; }
    public required string TituloTipoMaterial { get; init; }
    public required string UnidadeMedida { get; init; }
    public required string Descricao { get; init; }
    public int? QtdAdquirida { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Material, MaterialDto>()
                .ForMember(dest => dest.TituloTipoMaterial, opt => opt.MapFrom(src => src.TipoMaterial.Nome));
        }
    }
}
