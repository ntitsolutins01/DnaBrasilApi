﻿using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Application.Profissionais.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Contratos.Queries;
public class ContratoDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public required DateTime DtIni { get; set; }
    public required DateTime DtFim { get; set; }
    public string? Anexo { get; set; }
    public bool Status { get; set; } = true;
    //public List<LocalidadeDto>? Locais { get; set; }
    public List<AlunoDto>? Alunos { get; set; }
    public List<ProfissionalDto>? Profissionais { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contrato, ContratoDto>();
        }
    }
}