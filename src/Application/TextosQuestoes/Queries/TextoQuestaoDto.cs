using DnaBrasilApi.Application.TextosLaudos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TextosQuestoes.Queries;

public class TextoQuestaoDto
{
    public int Id { get; init; }
    public required int QuestaoEadId { get; init; }
    public string? Texto { get; init; }
    public Byte[]? Imagem { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TextoQuestao, TextoQuestaoDto>();
        }
    }
}
