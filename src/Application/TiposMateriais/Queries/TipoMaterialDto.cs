using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TiposMateriais.Queries;

public class TipoMaterialDto
{
    public required int Id { get; init; }
    public required int GrupoMaterialId { get; init; }
    public required string TituloGrupoMaterial { get; init; }
    public required string Nome { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TipoMaterial, TipoMaterialDto>()
                .ForMember(dest => dest.TituloGrupoMaterial, opt => opt.MapFrom(src => src.GrupoMaterial.Nome));
        }
    }
}
