using DnaBrasilApi.Application.Alunos.Queries;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries;
public class ControlesPresencasFilterDto
{

    #region SearchFilter
    public string? FomentoId { get; set; }
    public string? Estado { get; set; }
    public string? MunicipioId { get; set; }
    public string? LocalidadeId { get; set; }
    public string? DeficienciaId { get; set; }
    public string? Etnia { get; set; }
    #endregion

    public List<ControlePresencaDto>? ControlesPresencas { get; set; }
}
