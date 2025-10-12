using DnaBrasilApi.Application.Common.Models;

namespace DnaBrasilApi.Application.Eventos.Queries;
public class EventosFilterDto
{

    #region SearchFilter
    public required int PageNumber { get; set; } = 1;
    public required int PageSize { get; set; } = 10;
    public string? FomentoId { get; set; }
    public string? Estado { get; set; }
    public string? MunicipioId { get; set; }
    public string? LocalidadeId { get; set; }

    #endregion

    public PaginatedList<EventoDto>? Eventos { get; set; }
}
