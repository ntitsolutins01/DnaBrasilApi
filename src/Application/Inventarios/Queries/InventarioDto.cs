using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Inventarios.Queries;

public class InventarioDto
{
    public required int Id { get; init; }
    public required int MaterialId { get; init; }
    public required string NomeMaterial { get; init; }
    public required int LocalidadeId { get; init; }
    public required string NomeLocalidade { get; init; }
    public int? Quantidade { get; init; }
    public required string Motivo { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Inventario, InventarioDto>()
                .ForMember(dest => dest.NomeMaterial, opt => opt.MapFrom(src => src.Material.Descricao))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade.Nome));
        }
    }
}
