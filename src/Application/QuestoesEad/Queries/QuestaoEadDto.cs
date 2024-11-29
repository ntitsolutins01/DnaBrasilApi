using DnaBrasilApi.Application.RespostasEad.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.QuestoesEad.Queries;

public class QuestaoEadDto
{
    public int Id { get; init; }
    public required string NomeAula { get; init; }
    public string? Referencia { get; init; }
    public required string Pergunta { get; init; }
    public List<RespostaEadDto>? Respostas { get; init; }
    public required int Questao { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QuestaoEad, QuestaoEadDto>()
                .ForMember(dest => dest.NomeAula, opt => opt.MapFrom(src => src.Aula.Titulo));
        }
    }
}
