using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoDisciplinaDto
{
    public required string AlunoId { get; init; }
    public required string DisciplinaId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoDisciplina, AlunoDisciplinaDto>();
        }
    }
}
