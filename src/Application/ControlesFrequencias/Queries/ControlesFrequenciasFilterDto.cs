using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Application.ControlesFrequencias.Queries;

namespace DnaBrasilApi.Application.ControlesFrequencias.Queries;
public class ControlesFrequenciasFilterDto
{

    #region SearchFilter
    public required int PageNumber { get; set; } = 1;
    public required int PageSize { get; set; } = 10;
    public string? FomentoId { get; set; }
    public string? Estado { get; set; }
    public string? MunicipioId { get; set; }
    public string? LocalidadeId { get; set; }
    public string? DeficienciaId { get; set; }
    public string? Etnia { get; set; }
    #endregion

    public PaginatedList<ControleFrequenciaDto>? ControlesFrequencias { get; set; }
    public string? UsuarioEmail { get; set; }
}
