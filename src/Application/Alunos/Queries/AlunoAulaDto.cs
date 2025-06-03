using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoAulaDto
{
    public required string AlunoId { get; init; }
    public required string AulaId { get; init; }
    public int Progresso { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoAula, AlunoAulaDto>();
        }
    }
}
