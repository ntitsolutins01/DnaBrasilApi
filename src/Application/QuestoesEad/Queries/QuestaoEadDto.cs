using DnaBrasilApi.Application.RespostasEad.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.QuestionariosEad.Queries;

public class QuestaoEadDto
{
    public int Id { get; init; }
       
    public required string Pergunta { get; init; }
    public List<RespostaEadDto>? Respostas { get; init; }
    public required int Quadrante { get; init; }
    public required int Questao { get; init; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QuestaoEad, QuestaoEadDto>();
        }
    }
}
