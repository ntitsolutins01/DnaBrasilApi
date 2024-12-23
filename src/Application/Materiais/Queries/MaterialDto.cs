using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Materiais.Queries;

public class MaterialDto
{
    public required int Id { get; init; }
    public required int TipoMaterialId { get; set; }
    public required String UnidadeMedida { get; set; }
    public String? Descricao { get; set; }
    public int? QtdAdquirida { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Material, MaterialDto>();
        }
    }
}
