using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class VocacionalDto
{
    public int Id { get; init; }
    public required ProfissionalDto Profissional { get; init; }
    public Encaminhamento? Encaminhamento { get; init; }
    public required string Respostas { get; init; }
    public string? StatusVocacional { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Vocacional, VocacionalDto>();
        }
    }
}
