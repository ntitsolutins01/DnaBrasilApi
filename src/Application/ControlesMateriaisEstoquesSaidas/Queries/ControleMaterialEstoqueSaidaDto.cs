using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries;

public class ControleMaterialEstoqueSaidaDto
{
    public required int Id { get; init; }
    public required int MunicipioId { get; init; }
    public required int LocalidadeId { get; init; }
    public required int InventarioId { get; init; }
    public string? NomeMunicipio { get; init; }
    public string? NomeLocalidade { get; init; }
    public required string TituloMaterial { get; init; }
    public required int Quantidade { get; init; }
    public string? Solicitante { get; init; }
    public DateTimeOffset? Created { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControleMaterialEstoqueSaida, ControleMaterialEstoqueSaidaDto>()
                .ForMember(dest => dest.NomeMunicipio, opt => opt.MapFrom(src => src.Municipio.Nome))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Localidade.Nome))
                .ForMember(dest => dest.TituloMaterial, opt => opt.MapFrom(src => src.Inventario.Material.Descricao))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created));
        }
    }
}
