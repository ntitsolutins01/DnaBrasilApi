﻿using DnaBrasilApi.Application.Common.Models;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class LaudosFilterDto
{

    #region SearchFilter
    public required int PageNumber { get; set; } = 1;
    public required int PageSize { get; set; } = 500;
    public string? FomentoId { get; set; }
    public string? Estado { get; set; }
    public string? MunicipioId { get; set; }
    public string? LocalidadeId { get; set; }
    public string? AlunoId { get; set; }
    public string? TipoLaudoId { get; set; }

    #endregion

    public PaginatedList<LaudoDto>? Laudos { get; set; }
}
