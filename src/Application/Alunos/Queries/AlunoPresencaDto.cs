using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoPresencaDto
{
    public required string AlunoId { get; init; }
    public required string AulaId { get; init; }
    public required bool Presenca { get; init; }
    public string? Justificativa { get; init; }
    public required string Data { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoPresenca, AlunoPresencaDto>();
        }
    }
}
