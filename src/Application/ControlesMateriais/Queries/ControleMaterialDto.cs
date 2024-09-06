using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMateriais.Queries;

public class ControleMaterialDto
{
    public required int Id { get; init; }
    public required string NomeLinhaAcao { get; init; }
    public required string Descricao { get; init; }
    public required string UnidadeMedida { get; init; }
    public required int Quantidade { get; init; }
    public int? Saida { get; init; }
    public int? Disponivel { get; init; }
    public bool Status { get; init; }
   

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControleMaterial, ControleMaterialDto>()
                .ForMember(dest => dest.NomeLinhaAcao, opt => opt.MapFrom(src => src.LinhaAcao.Nome));
            ;
        }
    }
}
