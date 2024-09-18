using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.RespostasEad.Queries;

public class RespostaEadDto
{
    public int Id { get; init; }
    public required QuestaoEad Questao { get; init; }
    public required string TipoResposta { get; init; }
    public string? TipoAlternativa { get; init; }
    public required string Resposta { get; init; }
    public required decimal ValorPesoResposta { get; init; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RespostaEad, RespostaEadDto>();
        }
    }
}
