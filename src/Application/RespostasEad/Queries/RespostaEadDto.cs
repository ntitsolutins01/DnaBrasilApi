using DnaBrasilApi.Application.QuestionariosEad.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.RespostasEad.Queries;

public class RespostaEadDto
{
    public int Id { get; init; }
    public int QuestionarioEadId { get; init; }
    public required string Pergunta { get; set; }
    public required string RespostaQuestionarioEad { get; set; }
   public required decimal ValorPesoRespostaEad { get; set; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RespostaEad, RespostaEadDto>()
                .ForMember(dest => dest.QuestionarioEadId, opt => opt.MapFrom(src => src.QuestionarioEad!.Id))
                .ForMember(dest => dest.Pergunta, opt => opt.MapFrom(src =>
                    $"{src.QuestionarioEad.Questao}. {src.QuestionarioEad.Pergunta}"));
        }
    }
}
