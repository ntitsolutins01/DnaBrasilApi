namespace DnaBrasilApi.Application.Dashboards.Queries;
public class TotalizadorDeficienciaDto
{
    public Dictionary<string, decimal>? ValorTotalizadorDeficienciaMasculino { get; set; }
    public Dictionary<string, decimal>? ValorTotalizadorDeficienciaFeminino { get; set; }
    public Dictionary<string, decimal>? PercTotalizadorDeficienciaMasculino { get; set; }
    public Dictionary<string, decimal>? PercTotalizadorDeficienciaFeminino { get; set; }
    public Dictionary<string, decimal>? PercDeficiencia { get; set; }
}
