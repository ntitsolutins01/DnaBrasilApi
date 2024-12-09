using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class QualidadeDeVidaDto
{
    public required int Id { get; init; }
    public required Profissional Profissional { get; init; }
    public string? Encaminhamentos { get; init; }
    public required string Respostas { get; init; }
    public string? StatusQualidadeDeVida { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QualidadeDeVida, QualidadeDeVidaDto>();
        }
    }
}
