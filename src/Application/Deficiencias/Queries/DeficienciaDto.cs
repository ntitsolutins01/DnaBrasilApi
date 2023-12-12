using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Deficiencias.Queries;
public class DeficienciaDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public bool Status { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Deficiencia, DeficienciaDto>();
        }
    }
}
