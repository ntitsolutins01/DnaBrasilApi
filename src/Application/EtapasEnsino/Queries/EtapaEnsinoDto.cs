using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.EtapasEnsino.Queries;
public class EtapaEnsinoDto
{
    public required int Id { get; init; }
    public required string Nome { get; set; }
    public required bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EtapaEnsino, EtapaEnsinoDto>();
        }
    }
}
