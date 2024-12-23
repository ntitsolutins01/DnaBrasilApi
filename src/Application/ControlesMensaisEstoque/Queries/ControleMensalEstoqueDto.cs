using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMensaisEstoque.Queries;

public class ControleMensalEstoqueDto
{
    public required int Id { get; init; }
    public required int MaterialId { get; init; }
    public int? QtdPrevista { get; init; }
    public DateTime? DataMesSaida { get; init; }
    public int? TotalSaidas { get; init; }
    public int? TotalEstoque { get; init; }
    public int? QtdMateriaisDanificadosExtraviados { get; init; }
    public string? JustificativaDanificadosExtraviados { get; init; }
    public DateTime? DataDanificadosExtraviados { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControleMensalEstoque, ControleMensalEstoqueDto>();
        }
    }
}
