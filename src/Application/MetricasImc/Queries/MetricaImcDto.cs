using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.MetricasImc.Queries;
public class MetricaImcDto
{
    public int Id { get; set; }
    public int? Idade { get; init; }
    public string? Sexo { get; init; }
    public string? Classificacao { get; init; }
    public decimal ValorInicial { get; init; }
    public decimal ValorFinal { get; init; }
    public bool Status { get; init; } = true;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MetricaImc, MetricaImcDto>()
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => GetSexo(src.Sexo)));
        }
    }

    public static string GetSexo(string? sexo)
    {
        try
        {
            switch (sexo)
            {
                case "G":
                    return "Geral";
                case "F":
                    return "Feminino";
                case "M":
                    return "Masculino";
                default:
                    return "Não Definido";
            }
        }
        catch
        {
            return "Erro ao Definir";
        }
    }
}
