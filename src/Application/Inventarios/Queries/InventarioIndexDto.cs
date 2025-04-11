using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Inventarios.Queries;
public class InventarioIndexDto
{
    public required int Id { get; init; }
    public required string NomeMaterial { get; init; }
    public required string NomeLocalidade { get; init; }
    public required string NomeUndMedida { get; init; }
    public int? Quantidade { get; init; }
    public required string Motivo { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Inventario, InventarioIndexDto>()
                .ForMember(dest => dest.NomeMaterial, opt => opt.MapFrom(src => src.Material.Descricao))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade.Nome))
                .ForMember(dest => dest.NomeUndMedida, opt => opt.MapFrom(src => src.Material.UnidadeMedida));
        }
    }
}
