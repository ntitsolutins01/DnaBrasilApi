using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries;

public class ControleFrequenciaEscolarDto
{
    public required int Id { get; init; }
    public required string Controle { get; init; }
    public string? AlunoId { get; init; }
    public string? SerieId { get; init; }
    public string? DisciplinaId { get; init; }
    public string? ProfissionalId { get; init; }
    public required DateTime DataFrequencia { get; init; }
        private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControleFrequenciaEscolar, ControleFrequenciaEscolarDto>();
        }
    }
}
