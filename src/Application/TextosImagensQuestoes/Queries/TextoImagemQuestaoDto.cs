using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TextosImagensQuestoes.Queries;

public class TextoImagemQuestaoDto
{
    public int Id { get; init; }
    public required int QuestaoEadId { get; init; }
    public int Ordem { get; set; }
    public string? Tipo { get; set; }
    public string? TextoImagem { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TextoImagemQuestao, TextoImagemQuestaoDto>()
                .ForMember(dest => dest.QuestaoEadId, opt => opt.MapFrom(src => src.QuestaoEad.Id));
        }
    }
}
