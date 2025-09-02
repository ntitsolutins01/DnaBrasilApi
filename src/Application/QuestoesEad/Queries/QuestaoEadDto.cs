using DnaBrasilApi.Application.RespostasEad.Queries;
using DnaBrasilApi.Application.TextosImagensQuestoes.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.QuestoesEad.Queries;

public class QuestaoEadDto
{
    public int Id { get; init; }
    public required string NomeAula { get; init; }
    public string? Referencia { get; init; }
    public required string Enunciado { get; init; }
    public required int NumeroQuestao { get; init; }
    public IList<TextoImagemQuestaoDto>? TextosImagens { get; init; }
    public IList<RespostaEadDto>? Respostas { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QuestaoEad, QuestaoEadDto>()
                .ForMember(dest => dest.NomeAula, opt => opt.MapFrom(src => src.Aula.Titulo));
        }
    }
}
