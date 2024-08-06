using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Encaminhamentos.Queries;

public class EncaminhamentoDto
{
    public required int Id { get; set; }
    public required string Nome { get; init; }
    public required string NomeTipoLaudo { get; init; }
    public required string Parametro { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; set; }
   

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Encaminhamento, EncaminhamentoDto>()
                .ForMember(dest => dest.NomeTipoLaudo, opt => opt.MapFrom(src => src.TipoLaudo.Nome));
            ;
        }
    }
}
