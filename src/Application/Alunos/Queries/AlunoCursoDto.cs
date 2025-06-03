using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoCursoDto
{
    public required string AlunoId { get; init; }
    public required string CursoId { get; init; }
    public string? CertificadoId { get; init; }
    public int Progresso { get; init; }
    public bool Status { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoCursoCertificado, AlunoCursoDto>();
        }
    }
}
