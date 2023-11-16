using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Deficiencias.Queries;
public class DeficienciaDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public bool Status { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Deficiencia, DeficienciaDto>();
        }
    }
}
