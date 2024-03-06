using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Respostas.Queries;

public class RespostaDto
{
    public int Id { get; init; }
    public int QuestionarioId { get; init; }
    public required string Pergunta { get; set; }
    public int TipoLaudoId { get; init; }
    public required string NomeTipoLaudo { get; set; }
    public required string RespostaQuestionario { get; set; }
   public required decimal ValorPesoResposta { get; set; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Resposta, RespostaDto>()
                .ForMember(dest => dest.QuestionarioId, opt => opt.MapFrom(src => src.Questionario!.Id))
                .ForMember(dest => dest.Pergunta, opt => opt.MapFrom(src => src.Questionario!.Pergunta))
                .ForMember(dest => dest.TipoLaudoId, opt => opt.MapFrom(src => src.Questionario!.TipoLaudo.Id))
                .ForMember(dest => dest.NomeTipoLaudo, opt => opt.MapFrom(src => src.Questionario!.TipoLaudo.Nome));
        }
    }
}
