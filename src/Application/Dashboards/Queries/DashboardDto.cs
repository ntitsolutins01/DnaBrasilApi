﻿using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Parceiros.Queries;

namespace DnaBrasilApi.Application.Dashboards.Queries;
public class DashboardDto
{
    public int AvaliacoesDna { get; set; }
    public int LaudosAndamentos { get; set; }
    public int LaudosFinalizados { get; set; }
    public int CadastrosMasculinos { get; set; }
    public int CadastrosFemininos { get; set; }
    public int AlunosCadastrados { get; set; }
    public int LaudosMasculinos { get; set; }
    public int LaudosFemininos { get; set; }
    public int[]? ListPresencasAnual { get; set; }
    public int[]? ListFaltasAnual { get; set; }
    public StatusLaudosDto? StatusLaudos { get; set; }
    public int Ultimos3Meses { get; set; }
    public int Ultimos6Meses { get; set; }
    public int Em1Ano { get; set; }
    public Dictionary<string, decimal>? PercentualSaude { get; set; }
    public TotalizadorSexoSaudeDto? ListTotalizadorSaudeSexo { get; set; }
    public TotalizadorTalentoDto? ListTotalizadorTalento { get; set; }
    public TotalizadorDesempenhoDto? ListTotalizadorDesempenho { get; set; }
    public TotalizadorDeficienciaDto? ListTotalizadorDeficiencia { get; set; }
    public TotalizadorEtniaDto? ListTotalizadorEtnia { get; set; }
    public TotalizadorSaudeBucalDto? ListTotalizadorSaudeBucal { get; set; }
    public TotalizadorQualidadeVidaDto? ListTotalizadorQualidadeVida { get; set; }
    public TotalizadorConsumoAlimentarDto? ListTotalizadorConsumoAlimentar { get; set; }
    public VocacionalDto? ListTotalizadorVocacional { get; set; }

    #region SearchFilter
    public string? Sexo { get; set; }
    public string? StatusLaudo { get; set; }
    public string? FomentoId { get; set; }
    public string? Estado { get; set; }
    public string? MunicipioId { get; set; }
    public string? LocalidadeId { get; set; }
    public string? DeficienciaId { get; set; }
    public string? Etnia { get; set; }
    public string? Controle { get; set; }
    public VocacionalDto? RelatorioVocacional { get; set; }

    #endregion
}
