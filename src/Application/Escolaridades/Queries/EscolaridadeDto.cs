﻿using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Escolaridades.Queries;
public class EscolaridadeDto
{   
    public int Id { get; set; }
    public string? Nome { get; set; }
    public bool Status { get; set; }
    public List<AlunoDto> Alunos { get; } = new();
    public List<ProfissionalDto> Profissionais { get; } = new();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Escolaridade, EscolaridadeDto>();
        }
    }
}
