using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Disciplinas.Queries;
public class DisciplinaDto
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
    public string? Descricao { get; init; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Disciplina, DisciplinaDto>();
        }
    }
}
