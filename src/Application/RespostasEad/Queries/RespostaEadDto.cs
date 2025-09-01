using DnaBrasilApi.Application.QuestoesEad.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.RespostasEad.Queries;

public class RespostaEadDto
{
    public int Id { get; init; }
    public int QuestaoId { get; init; }
    public required string TipoResposta { get; init; }
    public required string Resposta { get; init; }
    public required decimal ValorPesoResposta { get; init; }
    public required string Enunciado { get; init; }
    public bool RespostaCerta { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RespostaEad, RespostaEadDto>()
                .ForMember(dest => dest.QuestaoId, opt => opt.MapFrom(src => src.Questao.Id))
                .ForMember(dest => dest.Enunciado, opt => opt.MapFrom(src => src.Questao.Enunciado));
        }
    }

}
