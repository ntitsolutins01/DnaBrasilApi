using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Deficiencias.Queries.GetDeficienciasAll;
public class DeficienciaDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public bool Status { get; init; }
    public List<Aluno> Alunos { get; } = new();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Deficiencia, DeficienciaDto>();
        }
    }
}
