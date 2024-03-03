using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Respostas.Queries;

public class RespostaDto
{
    public int Id { get; init; }
    public required string RespostaQuestionario { get; set; }
   public required QuestionarioDto Questionario { get; set; }
   public required int ValorPesoResposta { get; set; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Resposta, RespostaDto>();
        }
    }
}
