using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TiposMateriais.Queries;

public class TipoMaterialDto
{
    public required int Id { get; init; }
    public required int GrupoMaterialId { get; init; }
    public required String Nome { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoMaterial, TipoMaterialDto>();
        }
    }
}
