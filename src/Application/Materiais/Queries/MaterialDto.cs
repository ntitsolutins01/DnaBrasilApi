using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Materiais.Queries;

public class MaterialDto
{
    public required int Id { get; init; }
    public required int TipoMaterialId { get; init; }
    public required String UnidadeMedida { get; init; }
    public String? Descricao { get; init; }
    public int? QtdAdquirida { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Material, MaterialDto>();
        }
    }
}