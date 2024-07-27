namespace DnaBrasilApi.Application.Dashboards.Queries;
public class VocacionalDto
{
    public Dictionary<string, decimal>? PercTotalizadorVocacionalMasculino { get; set; }
    public Dictionary<string, decimal>? PercTotalizadorVocacionalFeminino { get; set; }
    public Dictionary<string, decimal>? ValorTotalizadorVocacionalMasculino { get; set; }
    public Dictionary<string, decimal>? ValorTotalizadorVocacionalFeminino { get; set; }
    public Dictionary<string, decimal>? PercentualVocacional { get; set; }
}
