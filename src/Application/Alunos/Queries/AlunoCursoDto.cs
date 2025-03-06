using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoCursoDto
{
    public required int AlunoId { get; init; }
    public required int CursoId { get; init; }
    public int Progresso { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoCurso, AlunoCursoDto>();
        }
    }
}
