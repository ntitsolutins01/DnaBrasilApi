using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.MetricasImc.Queries;
public class MetricaImcDto
{
    public int Id { get; set; }
    public int? TipoLaudoId { get; init; }
    public int? Idade { get; init; }
    public string? Sexo { get; init; }
    public string? NomeTipoLaudo { get; init; }
    public string? Classificacao { get; init; }
    public decimal ValorInicial { get; init; }
    public decimal ValorFinal { get; init; }
    public bool Status { get; init; } = true;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MetricaImc, MetricaImcDto>();
        }
    }
}
