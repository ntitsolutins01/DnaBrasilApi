﻿using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;
public class AlunosFilterDto
{

    #region SearchFilter
    public string? Matricula { get; set; }
    public string? Sexo { get; set; }
    public string? FomentoId { get; set; }
    public string? Estado { get; set; }
    public string? MunicipioId { get; set; }
    public string? LocalidadeId { get; set; }
    public string? DeficienciaId { get; set; }
    public string? Etnia { get; set; }
    public string? Nome { get; set; }
    #endregion

    public List<AlunoIndexDto>? Alunos { get; set; }
}
